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
        public SalViewModel Sal { get; }
        public ForestillingViewModel Forestilling { get; }


        private readonly IMessageService _msg;

        public MainViewModel(MovieViewModel movie, CinemaViewModel cinema, SalViewModel sal, ForestillingViewModel forestilling, IMessageService msg)
        {
            Movie = movie;
            Cinema = cinema;
            Sal = sal;
            Forestilling = forestilling;
            _msg = msg;


        }


       



    }
}
