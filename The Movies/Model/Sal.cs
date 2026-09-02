using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace The_Movies.Model
{
    public class Sal
    {
        public string Name { get; set; }

       
        public Cinema BiografDenTilhøre { get; set; }

        public Sal(string name, Cinema biografDenTilhøre)
        {
            Name = name; 
            BiografDenTilhøre = biografDenTilhøre;
        }

    }
}
