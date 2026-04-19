using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Mario
{
    internal class Teammate
    {
        string ranking;
        string name;

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public string Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }


        public Teammate(string name, string ranking)
        {
            Ranking = ranking;
            Name = name;
        }
    }
}
