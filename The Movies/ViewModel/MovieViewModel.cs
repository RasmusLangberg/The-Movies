using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using The_Movies.Model;
using The_Movies.ViewModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using The_Movies.Repository;
using The_Movies.Services;
using System.Windows;
using System.Windows.Controls;


namespace The_Movies.ViewModel
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        // vi bruger IMovieRepository interface til at definere en kontrakt for MovieRepository-klassen, som gør det muligt at ændre implementeringen af MovieRepository uden at ændre MovieViewModel-klassen.
        // ViewModel'en bruger interfacet som en kontrakt til Repository.
        // Det betyder, at ViewModel'en ikke behøver vide, hvordan data bliver gemt.

        private readonly IMovieRepository _repo;

        private readonly IMessageService _msg;


        // ObservableCollection indeholder de film, som View/ListBox skal vise.
        // ObservableCollection sørger for, at WPF automatisk opdager,
        // når en film bliver tilføjet eller fjernet.
        public ObservableCollection<Movie> Movies { get; set; }


        // Command som bliver bundet til "Tilføj"-knappen i XAML.
        public ICommand AddMovieCommand { get; }




        // Command som bliver bundet til "Slet"-knappen i XAML.
        public ICommand RemoveMovieCommand { get; }



        // Privat felt som gemmer den titel, brugeren skriver i TextBox.
        private string _title;

        // Property som TextBox'en binder til.
        // Når værdien ændres, sender OnPropertyChanged besked til WPF.
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                
                OnPropertyChanged(nameof(Title));
            }
        }

        // ?= må være null...bruges for at gøre det muligt at have null værdier i Length, da int ikke kan være null som standard. ellers står der 0 i texboxen når man åbner programmet, hvilket ikke er optimalt.
        private int? _length;
        public int? Length
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
        // Privat felt som holder den Movie, brugeren har valgt i ListBox.
        private Movie _selectedMovie;


        // SelectedItem fra ListBox'en bindes til denne property.
        // Den gør det muligt for ViewModel'en at vide,
        // hvilken film brugeren har valgt.

        // SelectedItem er en indbygget funktion i Listbox der gør man kan klikke på de oprettet film på listen 
        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set 
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }


        // Constructoren bliver kørt, når MovieViewModel bliver oprettet.
        // Repository bliver sendt ind udefra og gemt i _repo.
        public MovieViewModel(IMovieRepository repo, IMessageService msg)
        {

            // Gemmer det Repository, som ViewModel'en skal bruge.
            _repo = repo;
            _msg = msg;


            // Henter alle eksisterende film fra Repository.
            // Filmene lægges ind i ViewModel'ens ObservableCollection.
            Movies = new ObservableCollection<Movie>(_repo.GetAllMovies());

            // Opretter commanden til Tilføj-knappen.
            // Når commanden bliver kørt, kaldes AddMovie().
            AddMovieCommand = new RelayCommand(parameter => AddMovie());


            // Opretter commanden til Slet-knappen.
            // Når commanden bliver kørt, kaldes RemoveMovie().
            RemoveMovieCommand = new RelayCommand(parameter => RemoveMovie());


        }


        private void AddMovie()
        {
            if(Title==null || Length == null || Genre == null)
            {
                _msg.ShowMessage("Alle felter skal udfyldes");
                return;
            }
        

            Movie movie = new Movie(Title, Length.Value, Genre);
           
            // den her gemmer filmen i vores repositry. Interfacet gør at vi kan bagefter gemme filen på flere måder. ligenu gør vi det kun i en liste
            _repo.AddMovie(movie);

            // denne her hander om viewmodels egen "liste" som så kan vises i View
            Movies.Add(movie);
        }

        private void RemoveMovie()
        {
            //hvis filmen ikke findes stopper den, ellers fjerner den
            if (_repo.GetAllMovies().Count()==0)
            {
                _msg.ShowMessage("Ingen film er tilføjet til listen");
                return;
            }
            if (SelectedMovie == null)
            {
                _msg.ShowMessage("Du skal vælgte en film fra listen inden du trykker slet");
                return;
            }
            // fjerner fra vores repos
            _repo.RemoveMovie(SelectedMovie);

                // fjerner fra viewmodels "liste"
                Movies.Remove(SelectedMovie);

            

        }




        // Event som bruges af INotifyPropertyChanged.
        // WPF kan dermed få besked, når en property ændrer sig.
        public event PropertyChangedEventHandler? PropertyChanged;

        // Denne metode sender besked til WPF om,
        // at en bestemt property har ændret sig. uden PropertyChangedEventArgs ville WPF ikke opdatere det bruger ser på skærmen selvom værdien ædrede sig
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    } 
}