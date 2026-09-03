using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.Repository;
using The_Movies.ViewModel;

namespace The_Movies.ViewModel
{
    public class CinemaViewModel : ViewModelBase
    {
        private readonly ICinemaRepository _repo;

        public ICommand AddCinemaCommand { get; }
        public ICommand RemoveCinemaCommand { get; }

        public CinemaViewModel(ICinemaRepository cinemas)
        {
            _repo = cinemas;

            Cinemas = new ObservableCollection<Cinema>(
                _repo.GetAllCinemas()
            );

            AddCinemaCommand = new RelayCommand(parameter => AddCinema());
            RemoveCinemaCommand = new RelayCommand(parameter => RemoveCinema());
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _selectedNumberOfSale = 1;

        public int SelectedNumberOfSale
        {
            get => _selectedNumberOfSale;
            set
            {
                _selectedNumberOfSale = value;
                OnPropertyChanged(nameof(SelectedNumberOfSale));
            }
        }

        private ObservableCollection<Cinema> _cinemas;

        public ObservableCollection<Cinema> Cinemas
        {
            get => _cinemas;
            set
            {
                _cinemas = value;
                OnPropertyChanged(nameof(Cinemas));
            }
        }

        private Cinema _selectedCinema;

        public Cinema SelectedCinema
        {
            get => _selectedCinema;
            set
            {
                _selectedCinema = value;
                OnPropertyChanged(nameof(SelectedCinema));
            }
        }

        private void AddCinema()
        {
            // Opret en tom liste til salene
            List<Sal> sale = new List<Sal>();

            // Opret det antal sale som er valgt
            for (int i = 1; i <= SelectedNumberOfSale; i++)
            {
                sale.Add(new Sal($"Sal {i}"));
            }

            // Opret biografen med salene
            Cinema cinema = new Cinema(Name, sale);

            // Gem biografen
            _repo.AddCinema(cinema);

            // Tilføj til listen i UI
            Cinemas.Add(cinema);

            // Ryd navn
            Name = "";

            // Sæt antal tilbage til 1
            SelectedNumberOfSale = 1;
        }

        private void RemoveCinema()
        {
            if (SelectedCinema == null)
                return;

            _repo.RemoveCinema(SelectedCinema);

            Cinemas.Remove(SelectedCinema);

            SelectedCinema = null;
        }
    }
}



    

