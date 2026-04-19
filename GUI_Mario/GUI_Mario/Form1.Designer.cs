using System.Drawing;

namespace GUI_Mario
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartButt = new System.Windows.Forms.Button();
            this.FavButt = new System.Windows.Forms.Button();
            this.RandButt = new System.Windows.Forms.Button();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.Luke_Captain_listBox = new System.Windows.Forms.ListBox();
            this.Seth_Captain_listBox = new System.Windows.Forms.ListBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.Captain_Selection_Label = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SaveFave = new System.Windows.Forms.CheckBox();
            this.Seth_Team_Textbox = new System.Windows.Forms.TextBox();
            this.Luke_Team_Textbox = new System.Windows.Forms.TextBox();
            this.SameCaptainButton = new System.Windows.Forms.Button();
            this.TeamsHeader = new System.Windows.Forms.Label();
            this.weightedCheckbox = new System.Windows.Forms.CheckBox();
            this.Weighted_Teams_Label = new System.Windows.Forms.Label();
            this.weighted_tool_tip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // StartButt
            // 
            this.StartButt.Location = new System.Drawing.Point(305, 77);
            this.StartButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartButt.Name = "StartButt";
            this.StartButt.Size = new System.Drawing.Size(79, 34);
            this.StartButt.TabIndex = 0;
            this.StartButt.Text = "Start";
            this.StartButt.UseVisualStyleBackColor = true;
            this.StartButt.Click += new System.EventHandler(this.StartButt_Click);
            // 
            // FavButt
            // 
            this.FavButt.Location = new System.Drawing.Point(305, 128);
            this.FavButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FavButt.Name = "FavButt";
            this.FavButt.Size = new System.Drawing.Size(79, 34);
            this.FavButt.TabIndex = 2;
            this.FavButt.Text = "Favorite";
            this.FavButt.UseVisualStyleBackColor = true;
            this.FavButt.Click += new System.EventHandler(this.FavButt_Click);
            // 
            // RandButt
            // 
            this.RandButt.Location = new System.Drawing.Point(305, 178);
            this.RandButt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RandButt.Name = "RandButt";
            this.RandButt.Size = new System.Drawing.Size(79, 34);
            this.RandButt.TabIndex = 3;
            this.RandButt.Text = "Random";
            this.RandButt.UseVisualStyleBackColor = true;
            this.RandButt.Click += new System.EventHandler(this.RandButt_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(166, 7);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(351, 16);
            this.WelcomeLabel.TabIndex = 4;
            this.WelcomeLabel.Text = "Welcome to the Mario Sluggers Random Team Generator";
            // 
            // Luke_Captain_listBox
            // 
            this.Luke_Captain_listBox.FormattingEnabled = true;
            this.Luke_Captain_listBox.ItemHeight = 16;
            this.Luke_Captain_listBox.Items.AddRange(new object[] {
            "Mario",
            "Luigi",
            "Peach",
            "Daisy",
            "Yoshi",
            "Birdo",
            "Wario",
            "Waluigi",
            "Donkey_Kong",
            "Diddy_Kong",
            "Bowser",
            "Bowser_Jr.",
            "Random Captain"});
            this.Luke_Captain_listBox.Location = new System.Drawing.Point(83, 77);
            this.Luke_Captain_listBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Luke_Captain_listBox.Name = "Luke_Captain_listBox";
            this.Luke_Captain_listBox.Size = new System.Drawing.Size(145, 212);
            this.Luke_Captain_listBox.TabIndex = 5;
            this.Luke_Captain_listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Seth_Captain_listBox
            // 
            this.Seth_Captain_listBox.FormattingEnabled = true;
            this.Seth_Captain_listBox.ItemHeight = 16;
            this.Seth_Captain_listBox.Items.AddRange(new object[] {
            "Mario",
            "Luigi",
            "Peach",
            "Daisy",
            "Yoshi",
            "Birdo",
            "Wario",
            "Waluigi",
            "Donkey_Kong",
            "Diddy_Kong",
            "Bowser",
            "Bowser_Jr.",
            "Random Captain"});
            this.Seth_Captain_listBox.Location = new System.Drawing.Point(466, 77);
            this.Seth_Captain_listBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Seth_Captain_listBox.Name = "Seth_Captain_listBox";
            this.Seth_Captain_listBox.Size = new System.Drawing.Size(145, 212);
            this.Seth_Captain_listBox.TabIndex = 6;
            this.Seth_Captain_listBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(557, 306);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(116, 37);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // Captain_Selection_Label
            // 
            this.Captain_Selection_Label.AutoSize = true;
            this.Captain_Selection_Label.Location = new System.Drawing.Point(277, 7);
            this.Captain_Selection_Label.Name = "Captain_Selection_Label";
            this.Captain_Selection_Label.Size = new System.Drawing.Size(132, 16);
            this.Captain_Selection_Label.TabIndex = 8;
            this.Captain_Selection_Label.Text = "Select Your Captains";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(38, 26);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(116, 37);
            this.BackButton.TabIndex = 9;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(247, 292);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(78, 51);
            this.ResetButton.TabIndex = 10;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SaveFave
            // 
            this.SaveFave.AutoSize = true;
            this.SaveFave.Location = new System.Drawing.Point(281, 43);
            this.SaveFave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveFave.Name = "SaveFave";
            this.SaveFave.Size = new System.Drawing.Size(131, 20);
            this.SaveFave.TabIndex = 11;
            this.SaveFave.Text = "Save as Favorite";
            this.SaveFave.UseVisualStyleBackColor = true;
            this.SaveFave.CheckedChanged += new System.EventHandler(this.SaveFave_CheckedChanged);
            // 
            // Seth_Team_Textbox
            // 
            this.Seth_Team_Textbox.Location = new System.Drawing.Point(438, 98);
            this.Seth_Team_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Seth_Team_Textbox.Multiline = true;
            this.Seth_Team_Textbox.Name = "Seth_Team_Textbox";
            this.Seth_Team_Textbox.ReadOnly = true;
            this.Seth_Team_Textbox.Size = new System.Drawing.Size(173, 166);
            this.Seth_Team_Textbox.TabIndex = 12;
            // 
            // Luke_Team_Textbox
            // 
            this.Luke_Team_Textbox.Location = new System.Drawing.Point(83, 98);
            this.Luke_Team_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Luke_Team_Textbox.Multiline = true;
            this.Luke_Team_Textbox.Name = "Luke_Team_Textbox";
            this.Luke_Team_Textbox.ReadOnly = true;
            this.Luke_Team_Textbox.Size = new System.Drawing.Size(173, 166);
            this.Luke_Team_Textbox.TabIndex = 13;
            // 
            // SameCaptainButton
            // 
            this.SameCaptainButton.Location = new System.Drawing.Point(350, 292);
            this.SameCaptainButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SameCaptainButton.Name = "SameCaptainButton";
            this.SameCaptainButton.Size = new System.Drawing.Size(78, 51);
            this.SameCaptainButton.TabIndex = 14;
            this.SameCaptainButton.Text = "Same Captains";
            this.SameCaptainButton.UseVisualStyleBackColor = true;
            this.SameCaptainButton.Click += new System.EventHandler(this.SameCaptainButton_Click);
            // 
            // TeamsHeader
            // 
            this.TeamsHeader.AutoSize = true;
            this.TeamsHeader.Location = new System.Drawing.Point(306, 7);
            this.TeamsHeader.Name = "TeamsHeader";
            this.TeamsHeader.Size = new System.Drawing.Size(77, 16);
            this.TeamsHeader.TabIndex = 15;
            this.TeamsHeader.Text = "The Teams";
            // 
            // weightedCheckbox
            // 
            this.weightedCheckbox.AutoSize = true;
            this.weightedCheckbox.Location = new System.Drawing.Point(279, 43);
            this.weightedCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.weightedCheckbox.Name = "weightedCheckbox";
            this.weightedCheckbox.Size = new System.Drawing.Size(133, 20);
            this.weightedCheckbox.TabIndex = 16;
            this.weightedCheckbox.Text = "Weighted Teams";
            this.weightedCheckbox.UseVisualStyleBackColor = true;
            // 
            // Weighted_Teams_Label
            // 
            this.Weighted_Teams_Label.AutoSize = true;
            this.Weighted_Teams_Label.BackColor = System.Drawing.Color.White;
            this.Weighted_Teams_Label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Weighted_Teams_Label.Location = new System.Drawing.Point(35, 329);
            this.Weighted_Teams_Label.Name = "Weighted_Teams_Label";
            this.Weighted_Teams_Label.Size = new System.Drawing.Size(118, 16);
            this.Weighted_Teams_Label.TabIndex = 17;
            this.Weighted_Teams_Label.Text = "Weighted Teams?";
            this.Weighted_Teams_Label.Click += new System.EventHandler(this.label1_Click);
            this.Weighted_Teams_Label.MouseHover += new System.EventHandler(this.Weighted_Teams_Label_Mouse_Hover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.Weighted_Teams_Label);
            this.Controls.Add(this.weightedCheckbox);
            this.Controls.Add(this.TeamsHeader);
            this.Controls.Add(this.SameCaptainButton);
            this.Controls.Add(this.Luke_Team_Textbox);
            this.Controls.Add(this.Seth_Team_Textbox);
            this.Controls.Add(this.SaveFave);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.Captain_Selection_Label);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.Seth_Captain_listBox);
            this.Controls.Add(this.Luke_Captain_listBox);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.RandButt);
            this.Controls.Add(this.FavButt);
            this.Controls.Add(this.StartButt);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Mario Sluggers Random Team Selector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButt;
        private System.Windows.Forms.Button FavButt;
        private System.Windows.Forms.Button RandButt;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.ListBox Luke_Captain_listBox;
        private System.Windows.Forms.ListBox Seth_Captain_listBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label Captain_Selection_Label;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox SaveFave;
        private System.Windows.Forms.TextBox Seth_Team_Textbox;
        private System.Windows.Forms.TextBox Luke_Team_Textbox;
        private System.Windows.Forms.Button SameCaptainButton;
        private System.Windows.Forms.Label TeamsHeader;
        private System.Windows.Forms.CheckBox weightedCheckbox;
        private System.Windows.Forms.Label Weighted_Teams_Label;
        private System.Windows.Forms.ToolTip weighted_tool_tip;
    }
}

