using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model
{
    public class Forestilling
    {
        public Movie Movie { get; set; }
        public Sal Sal { get; set; }
        public DateTime StartTid { get; set; }

        public Forestilling(Movie movie, Sal sal, DateTime startTid)
        {
            Movie = movie;
            Sal = sal;
            StartTid = startTid;
        }

        public DateTime ReklameOgRengøringsTid(DateTime tid)
        {
            return tid.AddMinutes(30);
        }
    }
}
