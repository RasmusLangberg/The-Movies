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

        private readonly MovieViewModel _movieViewModel;

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

       


        private DateTime _startTid;
        public DateTime StartTid
        {
            get => _startTid;
            set { _startTid = value; OnPropertyChanged(nameof(StartTid)); }
        }



        public ForestillingViewModel(IForestillingRepository repo, MovieViewModel movie, SalViewModel salViewModel)
        {
            _repo = repo;
            _movieViewModel = movie;
            _salViewModel = salViewModel;
            Forestillinger = new ObservableCollection<Forestilling>(_repo.GetAllForestillinger());

            AddForestillingCommand = new RelayCommand(parameter => OpretForestilling());
            RemoveForestillingCommand = new RelayCommand(parameter => RemoveForestilling());
        }

        // Dette er metoden MainViewModel skal kalde med parametre

        private void OpretForestilling()
        {
            // 1. Tjek om brugeren rent faktisk har valgt en film
            if (SelectedForestilling == null)
            {
                MessageBox.Show("Venligst vælg en film først!");
                return;
            }

            Forestilling nyForestilling = new Forestilling(_movieViewModel.SelectedMovie, _salViewModel.SelectedSal, StartTid);

            Forestillinger.Add(nyForestilling);
        }

        public void RemoveForestilling()
        {
            if (SelectedForestilling == null) return;

            _repo.RemoveForestilling(SelectedForestilling);
            Forestillinger.Remove(SelectedForestilling);
        }
    }
}
