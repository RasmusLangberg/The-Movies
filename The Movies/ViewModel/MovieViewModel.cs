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


        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private int _length;
        public int Length
        {
            get => _length;
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        private string _genre;
        public string Genre
        {
            get => _genre;
            set
            {
                _genre = value;
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