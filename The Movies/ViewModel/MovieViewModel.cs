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
        // vi bruger IMovieRepository interface til at definere en kontrakt for MovieRepository-klassen, som gør det muligt at ændre implementeringen af MovieRepository uden at ændre MovieViewModel-klassen.

        private readonly IMovieRepository _repo;

        public ObservableCollection<Movie> Movies { get; set; }


        private string _Title;

        

        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private int _Length;
        public int Length
        {
            get => _Length;
            set
            {
                _Length = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        private string _Genre;
        public string Genre
        {
            get => _Genre;
            set
            {
                _Genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }


        public MovieViewModel(IMovieRepository repo)
        {
            _repo = repo;

            Movies = new ObservableCollection<Movie>(_repo.GetAllMovies());


        }









        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    } 
}