using System;
using System.Collections.Generic;
using System.Text;

namespace dare_or_dodge
{
    public class player
    {
        public string name;
        public int color;
        public int bank;
        public int wallet;

        public List<player> players = new List<player>();

        //constructor
        public player(string name, int color) 
        {
            this.name = name;
            this.color = color;
        }
    }
}
