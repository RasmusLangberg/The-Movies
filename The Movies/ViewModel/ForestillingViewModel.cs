using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.Repository;
using The_Movies.ViewModel;

namespace The_Movies.ViewModel
{
    public class ForestillingViewModel : ViewModelBase
    {
        private readonly IForestillingRepository _repo;

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

        private DateTime _startTid;
        public DateTime StartTid
        {
            get => _startTid;
            set { _startTid = value; OnPropertyChanged(nameof(StartTid)); }
        }



        public ForestillingViewModel(IForestillingRepository repo, CinemaViewModel cinemaViewModel, SalViewModel salViewModel   )
        {
            _repo = repo;
            _cinemaViewModel = cinemaViewModel;
            _salViewModel = salViewModel;
            Forestillinger = new ObservableCollection<Forestilling>(_repo.GetAllForestillinger());

            AddForestillingCommand = new RelayCommand(parameter => AddForestilling(parameter as Movie, parameter as Sal, DateTime.Now));
            RemoveForestillingCommand = new RelayCommand(parameter => RemoveForestilling());
        }

        // Dette er metoden MainViewModel skal kalde med parametre
        public void AddForestilling(Movie movie, Sal sal, DateTime startTid)
        {
            if (movie == null || sal == null) return;

            var forestilling = new Forestilling(movie, sal, startTid);
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
