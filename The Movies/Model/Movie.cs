using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model
{
    public class Movie
    {

        public string Title { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
    
        public Movie(string title, int length, string genre)
        {
            Title = title;
            Length = length;
            Genre = genre;
        }

    }
}
