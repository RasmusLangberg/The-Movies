using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.Repository;
using The_Movies.Services;

namespace The_Movies.ViewModel
{
    public class SalViewModel : ViewModelBase
    {

        private readonly ISalRepository _repo;

        private readonly ICinemaRepository _repoCinema;

        private readonly CinemaViewModel _cinemaViewModel;

        public ObservableCollection<Sal> Sale { get; set; }

        public ICommand AddCommandSal;

        public ICommand UpdateCommandSal;

        public ICommand RemoveCommandSal;

        //opret properties til view

        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
           
        }

        private int _antalSæder;

        public int AntalSæder
        {
            get { return _antalSæder; }
            set 
            { 
                _antalSæder = value;
                OnPropertyChanged(nameof(AntalSæder));
            }
        }

        private Sal _selectedSal;

        public  Sal SelectedSal
        {
            get { return _selectedSal; }
            set 
            { 
                _selectedSal = value;
                OnPropertyChanged(nameof(SelectedSal));
            }
        }


        public SalViewModel(ISalRepository repo, CinemaViewModel cinemaViewModel)
        {
            _repo = repo;
            _cinemaViewModel = cinemaViewModel;
            Sale = new ObservableCollection<Sal>(_repo.GetAllSale());
            UpdateCommandSal = new RelayCommand(paramter => UpdateSal());
            AddCommandSal = new RelayCommand(parameter => AddSal());
            RemoveCommandSal = new RelayCommand(parameter => RemoveSal());
        }

        public void UpdateSal()
        {


            var exsistingMovie = _repoCinema.GetCinemaByName(_cinemaViewModel.SelectedCinema.Name);

            if(exsistingMovie != null)
            {
                exsistingMovie.Name = _cinemaViewModel.Name;
                exsistingMovie.

            }


            Cinema cinima = new Cinema(_cinemaViewModel.Name,);

        }

        public void AddSal()
        {
            if (_cinemaViewModel.SelectedCinema == null) return;





        }

        public void RemoveSal()
        {

            _repo.RemoveSal(SelectedSal);
            Sale.Remove(SelectedSal);
        }
    }
}
