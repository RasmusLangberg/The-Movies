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

        public ObservableCollection<Cinema> Cinemas { get; set; }

        public ICommand AddCinemaCommand { get;}

        public ICommand RemoveCinemaCommand { get; }


        public CinemaViewModel(ICinemaRepository cinemas)
        {
            _repo = cinemas;


            new ObservableCollection<Cinema>(_repo.GetAllCinemas());



            AddCinemaCommand = new RelayCommand(Parameter => AddCinema());

            RemoveCinemaCommand = new RelayCommand(Parameter => RemoveCinema());

        }

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

        private int _screens;

        public int Screens
        {
            get { return _screens; }
            set 
            { 
                _screens = value;
                OnPropertyChanged(nameof(Screens));
            }
        }

        private Cinema _selectedCinema;

        public Cinema selectedCinema
        {
            get { return _selectedCinema; }
            set 
            { 
                _selectedCinema = value;
                OnPropertyChanged(nameof(selectedCinema));
            }
        }




        private void AddCinema()
        {



            Cinema cinema = new Cinema(Name);
            _repo.AddCinema(cinema);

        }

        private void RemoveCinema()
        {
            _repo.RemoveCinema(selectedCinema);



        }




    }
}
