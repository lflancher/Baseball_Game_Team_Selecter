using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace GUI_Mario
{
    public partial class Form1 : Form
    {
        //Here I make a new random area, and get the information from the files
        //This is where the information for the project is created
        Random r = new Random();
        string lukecaptain;
        string sethcaptain;
        string luketempfave;
        string sethtempfave;
        string[] luke_team                    = new string[9];
        string[] seth_team                    = new string[9];
        string[] captains                     = File.ReadAllLines("captains.txt");
        string[] teammates                    = File.ReadAllLines("teammates.txt");
        string[] faves                        = File.ReadAllLines("favorite.txt");
        string[] weighted_raw                 = File.ReadAllLines("weighted_teammates.txt");
        string[] chemistry_raw                = File.ReadAllLines("teammate_chemistry.txt");
        Teammate[] weightedteammates          = new Teammate[73];
        Chemistry_Pair[] weighted_chemistries = new Chemistry_Pair[71];
        Teammate[] luke_weighted_team         = new Teammate[9];
        Teammate[] seth_weighted_team         = new Teammate[9];


        public Form1()
        {
            InitializeComponent();
            HideExcess();
            ParseWeightedTeammates();
            ParseChemistry();
        }

        //This function is made to more easily reset the program. It essentially hides everything that isn't the start
        //Buttons and label.
        private void HideExcess()
        {
            Luke_Captain_listBox.Visible    = false;
            Seth_Captain_listBox.Visible    = false;
            NextButton.Visible              = false;
            Captain_Selection_Label.Visible = false;
            BackButton.Visible              = false;
            ResetButton.Visible             = false;
            Seth_Team_Textbox.Visible       = false;
            Luke_Team_Textbox.Visible       = false;
            SameCaptainButton.Visible       = false;
            TeamsHeader.Visible             = false;
            SaveFave.Checked                = false;
            //SaveFave is the checkbox, I should have called
            //it SaveFaveCheckBox. Too late now I guess.
            SaveFave.Visible = false;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Luke_Team_Textbox.TextAlign = HorizontalAlignment.Center;
            Seth_Team_Textbox.TextAlign = HorizontalAlignment.Center;
            weighted_tool_tip.SetToolTip(this.Weighted_Teams_Label, "What is a weighted team?");
        }

        //When the user clicks the button labeled "Start", the buttons "Random" and "Favorites" are hidden,
        //and the captain selection process begins.
        private void StartButt_Click(object sender, EventArgs e)
        {
            StartButt.Visible               = false;
            RandButt.Visible                = false;
            FavButt.Visible                 = false;
            WelcomeLabel.Visible            = false;
            Luke_Captain_listBox.Visible    = true;
            Seth_Captain_listBox.Visible    = true;
            NextButton.Visible              = true;
            Captain_Selection_Label.Visible = true;
            BackButton.Visible              = true;
            SaveFave.Visible                = true;
            weightedCheckbox.Visible        = false;
            Weighted_Teams_Label.Visible    = false;
        }

        //This just takes whatever was in the "faves" array and assigns them as captains.
        private void FavButt_Click(object sender, EventArgs e)
        {
            StartButt.Visible            = false;
            RandButt.Visible             = false;
            FavButt.Visible              = false;
            WelcomeLabel.Visible         = false;
            weightedCheckbox.Visible     = false;
            Weighted_Teams_Label.Visible = false;
            if (weightedCheckbox.Checked == true)
            {
                luke_weighted_team[0] = FindTeammate(faves[0]);
                seth_weighted_team[0] = FindTeammate(faves[1]);
                PickWeightedTeams();
            }
            else
            {
                luke_team[0] = faves[0];
                seth_team[0] = faves[1];
                PickTeams();
            }
                ShowTeams();
        }

        //Randomly selects the captains.
        private void RandButt_Click(object sender, EventArgs e)
        {
            WelcomeLabel.Visible            = false;
            StartButt.Visible               = false;
            RandButt.Visible                = false;
            FavButt.Visible                 = false;
            
            weightedCheckbox.Visible        = false;
            Weighted_Teams_Label.Visible    = false;
            
            PickCaptains();
            if (weightedCheckbox.Checked == true)
            {
                PickWeightedTeams();
            }
            else
            {
                PickTeams();
            }
            ShowTeams();

        }

        //This function picks captains at random
        //it always picks player 1's captain FIRST, and then
        //picks another captain, and if it is the same as
        //player 1 captain's picks another. This can go on
        //as long as it takes to pick a new captain
        private void PickCaptains()
        {
            int randlukecapindex = r.Next(0, captains.Length);
            int randsethcapindex = r.Next(0, captains.Length);
            bool samecaptain     = true;
            while (samecaptain == true)
            {
                if (randlukecapindex != randsethcapindex)
                {
                    samecaptain = false;
                }
                else
                {
                    randsethcapindex = r.Next(0, captains.Length);
                }
            }


            if (weightedCheckbox.Checked == true)
            {
                luke_weighted_team[0] = FindTeammate(captains[randlukecapindex]);
                seth_weighted_team[0] = FindTeammate(captains[randsethcapindex]);
            }

            else
            {
                luke_team[0] = captains[randlukecapindex];
                seth_team[0] = captains[randsethcapindex];
            }

        }

        //I made this function to ease readability.
        //You pass the captain you don't want selected, and the function
        //will pick a new one.
        private string PickedCap(string invalid_captain)
        {
            int randcapindex = r.Next(0, captains.Length);
            bool samecaptain = true;
            while (samecaptain == true)
            {
                if (invalid_captain != captains[randcapindex])
                {
                    samecaptain = false;
                }
                else
                {
                    randcapindex = r.Next(0, captains.Length);
                }
            }
            return captains[randcapindex];
        }

        //This function randomly selects the (non-captain) teammates.
        //It goes one team member at a time to reduce overhead, its algorithm is similar to that 
        //of the captain selection, but picks eight more players.
        private void PickTeams()
        {
            int randmemindex;
            int i = 1;
            bool luke_invalid;
            bool seth_invalid;
            while (i < 9)
            {
                luke_invalid = true;
                while (luke_invalid == true)
                {
                    randmemindex = r.Next(0, teammates.Length);
                    if (Isin(teammates[randmemindex], seth_team) == false && Isin(teammates[randmemindex], luke_team) == false)
                    {
                        luke_team[i] = teammates[randmemindex];
                        luke_invalid = false;
                    }
                }
                seth_invalid = true;
                while (seth_invalid == true)
                {
                    randmemindex = r.Next(0, teammates.Length);
                    if (Isin(teammates[randmemindex], seth_team) == false && Isin(teammates[randmemindex], luke_team) == false)
                    {
                        //seth_team.Append(teammates[randmemindex]);
                        seth_team[i] = teammates[randmemindex];
                        seth_invalid = false;
                    }
                }
                i++;
                
            }
        }

        //A simple "Isin" function
        private bool Isin(string x, string[] y)
        {
            for (int i = 0; i < y.Length; i++) 
            { 
                if (y[i] == x)
                {
                    return true;
                }
            }
            return false;
        }

        //A function to look for teammates, rather than a string.
        private bool Isinteammate(Teammate x, Teammate[] y)
        {
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] == x)
                {
                    return true;
                }
            }
            return false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //This function appends the team mates (including the captain) to the appropriate
        //text box.
        //The majority of this function is just going through the teammates before
        //showing the actual team for aesthetic purposes
        private void ShowTeams()
        {
            TeamsHeader.Visible = true;
            Luke_Team_Textbox.Visible = true;
            Seth_Team_Textbox.Visible = true;
            Teammate lukecaptain;
            Teammate sethcaptain;

            if (weightedCheckbox.Checked == true)
            {
                lukecaptain = luke_weighted_team[0];
                sethcaptain = seth_weighted_team[0];
                Seth_Team_Textbox.AppendText(sethcaptain.Name + "'s Team:\r\n");
                Luke_Team_Textbox.AppendText(lukecaptain.Name + "'s Team:\r\n");
                for (int i = 1; i < 35; i++)
                {
                    Thread.Sleep(1);
                    int n = r.Next(0, weightedteammates.Length - 9);
                    for (int j = 0; j < 8; j++)
                    {
                        Seth_Team_Textbox.AppendText(teammates[j + n] + "\r\n");
                        Luke_Team_Textbox.AppendText(teammates[j + n] + "\r\n");
                    }
                    Luke_Team_Textbox.Text = lukecaptain.Name + "'s Team:\r\n";
                    Seth_Team_Textbox.Text = sethcaptain.Name + "'s Team:\r\n";
                }

                Luke_Team_Textbox.Text = "";
                Seth_Team_Textbox.Text = "";

                //Correctly populating the textbox
                Seth_Team_Textbox.AppendText(sethcaptain.Name + "'s Team:\r\n");
                Luke_Team_Textbox.AppendText(lukecaptain.Name + "'s Team:\r\n");
                for (int i = 1; i < 9; i++)
                {
                    Luke_Team_Textbox.AppendText(luke_weighted_team[i].Name + "\r\n");
                    Seth_Team_Textbox.AppendText(seth_weighted_team[i].Name + "\r\n");
                }

            }

            else
            {
                Seth_Team_Textbox.AppendText(seth_team[0] + "'s Team:\r\n");
                Luke_Team_Textbox.AppendText(luke_team[0] + "'s Team:\r\n");

                for (int i = 1; i < 35; i++)
                {
                    Thread.Sleep(1);
                    int n = r.Next(0, teammates.Length - 9);
                    for (int j = 0; j < 8; j++)
                    {
                        Seth_Team_Textbox.AppendText(teammates[j + n] + "\r\n");
                        Luke_Team_Textbox.AppendText(teammates[j + n] + "\r\n");
                    }
                    
                    Luke_Team_Textbox.Text = luke_team[0] + "'s Team:\r\n";
                    Seth_Team_Textbox.Text = seth_team[0] + "'s Team:\r\n";
                }

                Luke_Team_Textbox.Text = "";
                Seth_Team_Textbox.Text = "";


                //Correctly populating the textbox.
                Seth_Team_Textbox.AppendText(seth_team[0] + "'s Team:\r\n");
                Luke_Team_Textbox.AppendText(luke_team[0] + "'s Team:\r\n");
                for (int i = 1; i < 9; i++)
                {
                    Seth_Team_Textbox.AppendText(seth_team[i] + "\r\n");
                    Luke_Team_Textbox.AppendText(luke_team[i] + "\r\n");
                }
            }

            ResetButton.Visible       = true;
            SameCaptainButton.Visible = true;
            
        }

        

        

        //This function is only used when the "Next" Button is clicked on the captain selection screen.
        //If both users selected "random captain", then I just call the function PickCaptains
        //If a "random captain" is selected, then I use the PickCaptain function
        //Otherwise it assigns the captains appropriately and if the user has selected
        //the "favorite" checkbox, it saves the user's preference.
        private void NextButton_Click(object sender, EventArgs e)
        {
            string SelectedCaptain;
            if ((Luke_Captain_listBox.SelectedIndex == Seth_Captain_listBox.SelectedIndex && Seth_Captain_listBox.SelectedIndex != 12)
                || Luke_Captain_listBox.SelectedIndex < 0 || Seth_Captain_listBox.SelectedIndex < 0)
            {
                MessageBox.Show("Invalid Captain Selection");
            }
            else
            {
                if (Luke_Captain_listBox.SelectedIndex == 12 && Seth_Captain_listBox.SelectedIndex == 12)
                {
                    PickCaptains();
                }
                else
                {
                    if (Luke_Captain_listBox.SelectedIndex == 12)
                    {
                        SelectedCaptain = Seth_Captain_listBox.GetItemText(Seth_Captain_listBox.SelectedItem);
                        luke_team[0] = PickedCap(SelectedCaptain);
                        if (weightedCheckbox.Checked == true)
                        {
                            luke_weighted_team[0] = FindTeammate(PickedCap(SelectedCaptain));
                            seth_weighted_team[0] = FindTeammate(SelectedCaptain);
                        }
                        seth_team[0] = SelectedCaptain;
                    }

                    else
                    {
                        if (Seth_Captain_listBox.SelectedIndex == 12)
                        {
                            SelectedCaptain = Luke_Captain_listBox.GetItemText(Luke_Captain_listBox.SelectedItem);
                            seth_team[0] = PickedCap(SelectedCaptain);
                            if (weightedCheckbox.Checked == true)
                            {
                                seth_weighted_team[0] = FindTeammate(PickedCap(SelectedCaptain));
                                luke_weighted_team[0] = FindTeammate(SelectedCaptain);
                            }
                            luke_team[0] = SelectedCaptain;
                        }

                        else
                        {
                            luke_team[0] = Luke_Captain_listBox.GetItemText(Luke_Captain_listBox.SelectedItem);
                            seth_team[0] = Seth_Captain_listBox.GetItemText(Seth_Captain_listBox.SelectedItem);
                            if (weightedCheckbox.Checked == true)
                            {
                                luke_weighted_team[0] = FindTeammate(Luke_Captain_listBox.GetItemText(Luke_Captain_listBox.SelectedItem));
                                seth_weighted_team[0] = FindTeammate(Seth_Captain_listBox.GetItemText(Seth_Captain_listBox.SelectedItem));
                            }
                            if (SaveFave.Checked)
                            {
                                SaveFavorites(luke_team[0], seth_team[0]);
                                SaveFave.Checked = false;
                            }

                        }
                        
                    }
                }
                HideExcess();
                if (weightedCheckbox.Checked == true)
                {
                    PickWeightedTeams();
                }
                else
                {
                    PickTeams();
                }
                ShowTeams();
            }
        }
        

        //The back button, it just goes back to the first screen by calling "Hide Excess"
        //And making the other buttons visible.
        private void BackButton_Click(object sender, EventArgs e)
        {
            HideExcess();
            StartButt.Visible            = true;
            RandButt.Visible             = true;
            FavButt.Visible              = true;
            WelcomeLabel.Visible         = true;
            weightedCheckbox.Visible     = true;
            Weighted_Teams_Label.Visible = true;
        }

        private void SaveFave_CheckedChanged(object sender, EventArgs e)
        {
        }

        //The function to save user's preferences as their fave captains.
        private void SaveFavorites(string lukefave, string sethfave)
        {
            string path = @"favorite.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(lukefave);
                sw.WriteLine(sethfave);
            }
            faves[0] = lukefave;
            faves[1] = sethfave;
        }

        //This resets the user's teams, calls the HideExcess function, makes the "Start", "Random" and "Favorite" buttons
        //visible, it also cleans out the team textboxes to save space and reduce confusion.
        private void ResetButton_Click(object sender, EventArgs e)
        {
            HideExcess();
            StartButt.Visible = true;
            RandButt.Visible = true;
            FavButt.Visible = true;
            WelcomeLabel.Visible = true;
            weightedCheckbox.Visible = true;
            Weighted_Teams_Label.Visible = true;
            for (int i = 0; i < 9; i++)
            {
                luke_team[i] = "";
                seth_team[i] = "";
                luke_weighted_team[i] = null;
                seth_weighted_team[i] = null;
            }
            Luke_Team_Textbox.Text = "";
            Seth_Team_Textbox.Text = "";
            //weightedCheckbox.Checked = false;
        }

        //If the user had so much fun with the captains or wants to just roll new teams without resetting the program
        //They can use the "Same Captains" Button, that will clear out the teams, minus the captains, clear out
        //the team textboxes minus the captains, and select new teams.
        private void SameCaptainButton_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                luke_team[i] = "";
                seth_team[i] = "";
                luke_weighted_team[i] = null;
                seth_weighted_team[i] = null;
            }
            if (weightedCheckbox.Checked)
            {
                Luke_Team_Textbox.Text = luke_weighted_team[0].Name + "'s Team:\r\n";
                Seth_Team_Textbox.Text = seth_weighted_team[0].Name + "'s Team:\r\n";
                PickWeightedTeams();
            }
            else
            {
                Luke_Team_Textbox.Text = luke_team[0] + "'s Team:\r\n";
                Seth_Team_Textbox.Text = seth_team[0] + "'s Team:\r\n";
                PickTeams();
            }
            ShowTeams();
        }

        //This function takes the raw data from the weighted teammate ranking 
        //and then makes teammates that have weighted rankings.
        private void ParseWeightedTeammates()
        {
            String[] weighted_teammate;
            for (int i = 0; i < weighted_raw.Length; i++)
            {
                weighted_teammate = weighted_raw[i].Split(':');
                Teammate added_teammate = new Teammate(weighted_teammate[0], weighted_teammate[1]);
                weightedteammates[i] = added_teammate;
            }
        }

        private void ParseChemistry()
        {
            String[] teammate_chemistry;
            String[] chemical_teammates;
            for (int i = 0; i < chemistry_raw.Length; i++)
            {
                teammate_chemistry = chemistry_raw[i].Split(':', ',');
                chemical_teammates = new string[teammate_chemistry.Length - 1];
                for (int j = 1; j < teammate_chemistry.Length; j++)
                {
                    chemical_teammates[j - 1] = teammate_chemistry[j];
                }
                Chemistry_Pair added_pair = new Chemistry_Pair(teammate_chemistry[0], chemical_teammates);
                weighted_chemistries[i] = added_pair;
            }
        }


        //This function selects a teammate at random that is not already on either team
        //That teammate's appropriate chemistries must also not be restricted to fewer than 2 players
        //Then two of those chemistry-friendly characters are chosen and added to the team.
        //The function then counts the amount of S-Rank players on both teams (including captains)
        //It then balances it by adding enough S-Ranks to the team with fewer S-Ranked players
        //The rest of the players are chosen randomly.
        private void PickWeightedTeams()
        {
            int lukefailsafecounter = 0;
            int sethfailsafecounter = 0;
            int randteamindex;
            int randchemindex;
            bool lukevalid = false;
            bool sethvalid = false;
            Teammate luke_chemistry_teammate;
            Teammate seth_chemistry_teammate;
            int available_luke_teammates = 0;
            int available_seth_teammates = 0;
            int available_spots = 3;
            //Pick a random teammate, doesn't matter.
            randteamindex = r.Next(0, weighted_chemistries.Length);
            randchemindex = r.Next(0, weighted_chemistries.Length);
            while (lukevalid == false)
            {
                randteamindex = r.Next(0, weighted_chemistries.Length);
                luke_chemistry_teammate = FindTeammate(weighted_chemistries[randteamindex].Teammate_name);
                if (IsRepeatWeighted(luke_chemistry_teammate) == false)
                {
                    for (int i = 0; i < weighted_chemistries[randteamindex].Chemistry_characters.Length; i++)
                    {
                        if (IsRepeatWeighted(FindTeammate(weighted_chemistries[randteamindex].Chemistry_characters[i])) == false)
                        {
                            available_luke_teammates = available_luke_teammates + 1;
                        }
                    }
                    if (available_luke_teammates >= available_spots)
                    {
                        lukevalid = true;
                        luke_weighted_team[1] = luke_chemistry_teammate;

                    }
                }
                
            }

            int j = 0;
            while (j < 2) 
            {
                randchemindex = r.Next(0, weighted_chemistries[randteamindex].Chemistry_characters.Length);
                if (IsRepeatWeighted(FindTeammate(weighted_chemistries[randteamindex].Chemistry_characters[randchemindex])) == false)
                {
                    luke_weighted_team[j + 2] = FindTeammate(weighted_chemistries[randteamindex].Chemistry_characters[randchemindex]);
                    j++;
                }
                lukefailsafecounter++;
                if (lukefailsafecounter > 999)
                {
                    failsafe();
                }
            }

            while (sethvalid == false)
            {
                randteamindex = r.Next(0, weighted_chemistries.Length);
                seth_chemistry_teammate = FindTeammate(weighted_chemistries[randteamindex].Teammate_name);
                if (IsRepeatWeighted(seth_chemistry_teammate) == false)
                {
                    for (int i = 0; i < weighted_chemistries[randteamindex].Chemistry_characters.Length; i++)
                    {
                        if (IsRepeatWeighted(FindTeammate(weighted_chemistries[randteamindex].Chemistry_characters[i])) == false)
                        {
                            available_seth_teammates = available_seth_teammates + 1;
                        }
                    }

                    if (available_seth_teammates >= available_spots)
                    {
                        sethvalid = true;
                        seth_weighted_team[1] = seth_chemistry_teammate;
                    }
                }
                
            }

            j = 0;

            while (j < 2)
            {
                randchemindex = r.Next(0, weighted_chemistries[randteamindex].Chemistry_characters.Length);
                if (IsRepeatWeighted(FindTeammate(weighted_chemistries[randteamindex].Chemistry_characters[randchemindex])) == false)
                {
                    seth_weighted_team[j + 2] = FindTeammate(weighted_chemistries[randteamindex].Chemistry_characters[randchemindex]);
                    j++;
                }
                sethfailsafecounter++;
                if (sethfailsafecounter > 999)
                {
                    failsafe();
                }
            }

            lukevalid = false;
            sethvalid = false;
            int mores;
            int k = 0;
            int luke_s_count = Countranking("S", luke_weighted_team);
            int seth_s_count = Countranking("S", seth_weighted_team);
            if (luke_s_count > seth_s_count)
            {
                mores = luke_s_count - seth_s_count;
                while (k < mores && (luke_s_count + seth_s_count < Countranking("S", weightedteammates)))
                {
                    randteamindex = r.Next(0, weightedteammates.Length);
                    if (IsRepeatWeighted(weightedteammates[randteamindex]) == false && weightedteammates[randteamindex].Ranking == "S")
                    {
                        seth_weighted_team[k + 4] = weightedteammates[randteamindex];
                        k++;
                    }
                }
            }
            else
            {
                if (luke_s_count < seth_s_count)
                {
                    mores = seth_s_count - luke_s_count;
                    while (k < mores && (luke_s_count + seth_s_count <  Countranking("S", weightedteammates)))
                    {
                        randteamindex = r.Next(0, weightedteammates.Length);
                        if (IsRepeatWeighted(weightedteammates[randteamindex]) == false && weightedteammates[randteamindex].Ranking == "S")
                        {
                            luke_weighted_team[k + 4] = weightedteammates[randteamindex];
                            k++;
                        }
                    }
                }
            }
            


            int luke_nulls = CountNulls(luke_weighted_team);
            int seth_nulls = CountNulls(seth_weighted_team);
            lukevalid = false;
            sethvalid = false;
            
            while(luke_nulls > 0)
            {
                lukevalid = false;
                while (lukevalid == false)
                {
                    randteamindex = r.Next(0, weightedteammates.Length);
                    if (IsRepeatWeighted(weightedteammates[randteamindex]) == false)
                    {
                        luke_weighted_team[9 - luke_nulls] = weightedteammates[randteamindex];
                        luke_nulls--;
                        lukevalid = true;
                        
                    }
                }
            }

            while(seth_nulls > 0)
            {
                sethvalid = false;
                while (sethvalid == false)
                {
                    randteamindex = r.Next(0, weightedteammates.Length);
                    if (IsRepeatWeighted(weightedteammates[randteamindex]) == false)
                    {
                        seth_weighted_team[9 - seth_nulls] = weightedteammates[randteamindex];
                        seth_nulls--;
                        sethvalid = true;
                        
                    }
                }
            }
        }

        
        private int CountNulls(Teammate[] n_teammates)
        {
            int count = 0;
            for (int i = 0; i < n_teammates.Length; i++)
            {
                if (n_teammates[i] != null)
                {
                    count++;
                }
            }
            return 9 - count;
        }
        
        private bool IsRepeatWeighted(Teammate teammate)
        {
            if (Isinteammate(teammate, seth_weighted_team) == false
                    && Isinteammate(teammate, luke_weighted_team) == false)
            {
                return false;
            }
            return true;
        }

        //This function counts the amount of rankings a team has. It is used to make sure there are not too many
        //of one ranking or too few of another.
        private int Countranking(string rankingtocount, Teammate[] lookteam)
        {
            int number_of_ranking = 0;
            int i = 0;
            while (i < lookteam.Length && lookteam[i] != null)
            {
                if (lookteam[i].Ranking == rankingtocount)
                {
                    number_of_ranking++;
                }
                i++;
            }
            return number_of_ranking;
        }

        //Uses a captain's name to find the respective "teammate" object.
        private Teammate FindTeammate(string teammatename)
        {
            for (int i = 0; i < weightedteammates.Length; i++)
            {
                if (weightedteammates[i].Name == teammatename)
                {
                    return weightedteammates[i];
                }
            }
            MessageBox.Show("Unable to find player: " + teammatename);
            BackButton.Click += BackButton_Click;
            return null;
        }
        private void weighted_button_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Weighted Teams\" are teams that are guarenteed to" +
                " have at least one chemistry \'V\'. It also does a small amount of balancing based on the captain " +
                "and chemistry \'V\' to avoid strategic captain selection. There is still an element of randomness and " +
                "one team could still be significantly \"better\" than the other.");
        }

        private void Weighted_Teams_Label_Mouse_Hover(object sender, EventArgs e)
        {
        }

        //In the event an infinite loop occurs, the program just tries again.
        private void failsafe()
        {
            for (int i = 1; i < 9; i++)
            {
                luke_team[i] = "";
                seth_team[i] = "";
                luke_weighted_team[i] = null;
                seth_weighted_team[i] = null;
            }
            Luke_Team_Textbox.Text = "";
            Seth_Team_Textbox.Text = "";
            if (weightedCheckbox.Checked)
            {
                PickWeightedTeams();
            }
            else
            {
                PickTeams();
            }
            ShowTeams();
        }
    }
}
