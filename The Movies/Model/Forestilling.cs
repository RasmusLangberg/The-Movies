using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model
{
    public class Forestilling
    {
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
        public Sal Sal { get; set; }
        public string StartTid { get; set; }

        public string SlutTid => BeregnSlutTid(StartTid, Movie.Length);

        private static string BeregnSlutTid(string startTid, int varighedMinutter)
        {
            if (!TimeSpan.TryParse(startTid, out TimeSpan start))
                return "??:??";

            TimeSpan slut = start.Add(TimeSpan.FromMinutes(varighedMinutter + 30));
            return slut.ToString(@"hh\:mm");
        }

        public Forestilling(Movie movie, Cinema cinema, Sal sal, string startTid)
        {
            Movie = movie;
            Cinema = cinema;
            Sal = sal;
            StartTid = startTid;
        }

        public override string ToString()
        {
            return $"{Movie.Title} - {Cinema.Name} - {Sal.Name} - {StartTid} til {SlutTid}";
        }
    }
}
