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

        public ICommand AddCinemaCommand { get;}

        public ICommand RemoveCinemaCommand { get; }


        public CinemaViewModel(ICinemaRepository cinemas)
        {
            _repo = cinemas;


            Cinemas = new ObservableCollection<Cinema>(_repo.GetAllCinemas());



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
            get { return _selectedCinema; }
            set 
            { 
                _selectedCinema = value;
                OnPropertyChanged(nameof(SelectedCinema));
            }
        }




        private void AddCinema()
        {
            Cinema cinema = new Cinema(Name);
            _repo.AddCinema(cinema);

            Cinemas.Add(cinema);

        }

        private void RemoveCinema()
        {
            _repo.RemoveCinema(SelectedCinema);

            Cinemas.Remove(SelectedCinema);



        }




    }
}
