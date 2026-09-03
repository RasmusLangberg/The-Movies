using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.Repository;
using The_Movies.ViewModel;

namespace The_Movies.ViewModel
{
    public class ForestillingViewModel : ViewModelBase
    {
        private readonly IForestillingRepository _repo;

        private readonly IMovieRepository _repoMovie;

        private readonly MovieViewModel _movieViewModel;

        private readonly CinemaViewModel _cinemaViewModel;

        private readonly SalViewModel _salViewModel;  

        public ObservableCollection<Forestilling> Forestillinger { get; set; }

        public ICommand AddForestillingCommand { get; }
        public ICommand RemoveForestillingCommand { get; }


        private Forestilling _selectedForestilling;
        public Forestilling SelectedForestilling
        {
            get => _selectedForestilling;
            set { _selectedForestilling = value; OnPropertyChanged(nameof(SelectedForestilling)); }
        }

        private Forestilling _selectedSal;
        public Forestilling SelectedSal
        {
            get => _selectedSal;
            set { _selectedSal = value; OnPropertyChanged(nameof(SelectedSal)); }
        }

       


        private string _startTid;
        public string StartTid
        {
            get => _startTid;
            set { _startTid = value; OnPropertyChanged(nameof(StartTid)); }
        }



        public ForestillingViewModel(IForestillingRepository forestillingRepo,IMovieRepository movieRepo,CinemaViewModel cinemaViewModel,SalViewModel salViewModel,MovieViewModel movieViewModel)
        {
            _repo = forestillingRepo;
            _repoMovie = movieRepo;
            _cinemaViewModel = cinemaViewModel;
            _salViewModel = salViewModel;
            _movieViewModel = movieViewModel;

            Forestillinger = new ObservableCollection<Forestilling>(
                _repo.GetAllForestillinger()
            );

            AddForestillingCommand = new RelayCommand(parameter => AddForestilling());
            RemoveForestillingCommand = new RelayCommand(parameter => RemoveForestilling());
        }

      

        private void AddForestilling()
        {
            if (_cinemaViewModel.SelectedCinema == null)
                return;

            if (_cinemaViewModel.SelectedCinema.Sale == null)
                return;

            if (_salViewModel.SelectedSal == null)
                return;

            if (_movieViewModel.SelectedMovie == null)
                return;

            if (string.IsNullOrEmpty(StartTid))
                return;

            Forestilling forestilling = new Forestilling(
                _movieViewModel.SelectedMovie,
                _cinemaViewModel.SelectedCinema,
                _salViewModel.SelectedSal,
                StartTid
            );

            _repo.AddForestilling(forestilling);

            Forestillinger.Add(forestilling);
        }

        public void RemoveForestilling()
        {
            if (SelectedForestilling == null) return;

            _repo.RemoveForestilling(SelectedForestilling);
            Forestillinger.Remove(SelectedForestilling);
        }
    }
}
