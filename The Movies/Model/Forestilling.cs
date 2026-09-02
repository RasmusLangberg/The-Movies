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

       


        public DateTime ReklameOgRengøringsTid(DateTime tid)
        {
            tid.AddMinutes(30);

            return tid;
        }
        
    }
}
