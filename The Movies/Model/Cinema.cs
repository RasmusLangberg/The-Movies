using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model
{
    public class Cinema
    {
        public string Name { get; set; }
        public List<Sal> Sale { get; set; } = new List<Sal>();

        public Cinema(string name, List<Sal> sale)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Biografen skal have et navn.", nameof(name));

            Name = name;
            Sale = sale;
        }

       

        public override string ToString()
        {
            if (Sale != null && Sale.Count > 0)
            {
                string salNavne = string.Join(", ", Sale.Select(s => s.Name));
                return $"{Name} (Sale: {salNavne})";
            }
            return Name;
        }
    }
}
