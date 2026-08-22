using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using The_Movies.Model.Repository;
using The_Movies.Model;
using The_Movies.ViewModel;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace The_Movies.ViewModel
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private readonly IMovieRepository _repo;

        private List<Movie> _movies;

    }
}
