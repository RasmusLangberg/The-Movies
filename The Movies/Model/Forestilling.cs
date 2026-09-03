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
        public DateOnly Dato { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public TimeSpan StartTid { get; set; }

        public TimeSpan SlutTid => calculateEndTime(StartTid, Movie.Length);

        private static TimeSpan calculateEndTime(TimeSpan startTid, int varighedMinutter)
        {
            return startTid.Add(TimeSpan.FromMinutes(varighedMinutter + 30));
        }

        public Forestilling(Movie movie, Cinema cinema, Sal sal, DateOnly dato, TimeSpan startTid)
        {
            Movie = movie;
            Cinema = cinema;
            Sal = sal;
            Dato = dato;
            StartTid = startTid;
        }

        public override string ToString()
        {
            return $"{Movie.Title} - {Cinema.Name} - {Sal.Name} - {Dato} - {StartTid} til {SlutTid}";
        }
    }
}
