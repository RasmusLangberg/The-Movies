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
        public string Director { get; set; }


        public DateOnly ReleaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public Movie()
        {
            Title = string.Empty;
            Genre = string.Empty;
            Director = string.Empty;
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Movie(string title, int length, string genre, string director, DateTime releaseDate)
        {
            Title = title;
            Length = length;
            Genre = genre;
            Director = director;
            ReleaseDate = DateOnly.FromDateTime(releaseDate);
        }

        public override string ToString()
        {
            return $"{Title} - {Genre} - {Length} minutter - {Director} - {ReleaseDate}";
        }

    }
}
