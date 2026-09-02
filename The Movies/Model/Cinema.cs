using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model
{
    public class Cinema
    {
		public string Name { get; set; }

        public List<Sal> Sale { get; set; } = new List<Sal>();

        public Cinema(string name)
        {
            Name = name;
        
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
