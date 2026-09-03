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

        public ICommand AddCommandSal { get; }
        public ICommand UpdateCommandSal { get; }
        public ICommand RemoveCommandSal { get; }

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

        private int _selectedNumberOfSale;

        public int SelectedNumberOfSale
        {
            get => _selectedNumberOfSale;
            set
            {
                _selectedNumberOfSale = value;
                OnPropertyChanged(nameof(SelectedNumberOfSale));
            }
        }

        private Sal _selectedSal;

        public Sal SelectedSal
        {
            get => _selectedSal;
            set
            {
                _selectedSal = value;
                OnPropertyChanged(nameof(SelectedSal));
            }
        }

        public SalViewModel(
            ISalRepository repo,
            ICinemaRepository repoCinema,
            CinemaViewModel cinemaViewModel)
        {
            _repo = repo;
            _repoCinema = repoCinema;
            _cinemaViewModel = cinemaViewModel;

            Sale = new ObservableCollection<Sal>();

            AddCommandSal = new RelayCommand(parameter => AddSal());
            RemoveCommandSal = new RelayCommand(parameter => RemoveSal());
        }

        public void AddSal()
        {
            // Tjek om en biograf er valgt
            if (_cinemaViewModel.SelectedCinema == null)
                return;

            // Tjek om antal sale er valgt
            if (SelectedNumberOfSale <= 0)
                return;

            Cinema cinema = _cinemaViewModel.SelectedCinema;

            // Opret det antal sale som er valgt
            for (int i = 1; i <= SelectedNumberOfSale; i++)
            {
                Sal sal = new Sal($"Sal {i}");

                // Tilføj salen til den valgte biograf
                cinema.Sale.Add(sal);

                // Tilføj også til den lokale liste
                Sale.Add(sal);
            }

            // Opdater UI
            OnPropertyChanged(nameof(Sale));

            // Nulstil antal
            SelectedNumberOfSale = 0;
        }

        public void RemoveSal()
        {
            if (SelectedSal == null)
                return;

            Cinema cinema = _cinemaViewModel.SelectedCinema;

            if (cinema == null)
                return;

            // Fjern salen fra biografen
            cinema.Sale.Remove(SelectedSal);

            // Fjern fra listen
            Sale.Remove(SelectedSal);

            // Fjern fra repository
            _repo.RemoveSal(SelectedSal);

            SelectedSal = null;

            OnPropertyChanged(nameof(Sale));
        }
    }
}
