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
           
            List<Sal> sale = new List<Sal>();

            
            for (int i = 1; i <= SelectedNumberOfSale; i++)
            {
                sale.Add(new Sal($"Sal {i}"));
            }

            
            Cinema cinema = new Cinema(Name, sale);

            
            _repo.AddCinema(cinema);

            
            Cinemas.Add(cinema);

            
            Name = "";

            
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



    

