using System;
using System.Collections.Generic;
using System.Text;
using The_Movies.Services;

namespace The_Movies.ViewModel
{
    public class MainViewModel
    {
        
        public MovieViewModel Movie { get; }

        public CinemaViewModel Cinema { get; }

        private readonly IMessageService _msg;

        public MainViewModel(MovieViewModel movie, CinemaViewModel cinema, IMessageService msg)
        {
            Movie = movie;
            Cinema = cinema;
            _msg = msg;


        }



    }
}
