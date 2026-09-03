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

        public string SlutTid => BeregnSlutTid(StartTid, Movie?.Length ?? 0);

        private static string BeregnSlutTid(string startTid, int varighedMinutter)
        {
            if (string.IsNullOrEmpty(startTid) || !TimeSpan.TryParse(startTid, out TimeSpan start))
                return "??:??";

            TimeSpan slut = start.Add(TimeSpan.FromMinutes(varighedMinutter + 30));
            return slut.ToString(@"hh\:mm");
        }

        public Forestilling()
        {
            Movie = null;
            Cinema = null;
            Sal = null;
            StartTid = string.Empty;
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
            return $"{Movie?.Title ?? "N/A"} - {Cinema?.Name ?? "N/A"} - {Sal?.Name ?? "N/A"} - {StartTid} til {SlutTid}";
        }
    }
}
