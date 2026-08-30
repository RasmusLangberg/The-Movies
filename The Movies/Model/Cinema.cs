using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model
{
    public class Cinema
    {
		public string Name { get; set; }

        public int Screens { get; set; }


        public Cinema(string name, int screens)
        {
            Name = name;
            Screens = screens;
        }


    }
}
