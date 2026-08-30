using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.ViewModel
{
    public class MainViewModel
    {
        
        public MovieViewModel Movie { get; }

        public CinemaViewModel Cinema { get; }


        public MainViewModel(MovieViewModel movie, CinemaViewModel cinema)
        {
            Movie = movie;
            Cinema = cinema;
        }



    }
}
