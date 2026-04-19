using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Mario
{
    internal class Chemistry_Pair
    {
        string teammate_name;
        string[] chemistry_characters;

        public string Teammate_name
        {
            get { return teammate_name; }
            set { teammate_name = value; }
        }

        public string[] Chemistry_characters
        {
            get { return chemistry_characters; }
            set { chemistry_characters = value; }
        }

        public Chemistry_Pair(string teammate_name, string[] chemistry_characters)
        {
            Teammate_name = teammate_name;
            Chemistry_characters = chemistry_characters;
        }
    }
}
