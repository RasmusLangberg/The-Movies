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

        private Sal _selectedSal;
        public Sal SelectedSal
        {
            get => _selectedSal;
            set
            {
                _selectedSal = value;
                OnPropertyChanged(nameof(SelectedSal));

                // Når en sal vælges i UI, fyldes tekstfeltet automatisk
                if (_selectedSal != null)
                {
                    Name = _selectedSal.Name;
                }
            }
        }

        public SalViewModel(ISalRepository repo, ICinemaRepository repoCinema, CinemaViewModel cinemaViewModel)
        {
            _repo = repo;
            _repoCinema = repoCinema; // Modtag repo via Dependency Injection
            _cinemaViewModel = cinemaViewModel;

            Sale = new ObservableCollection<Sal>(_repo.GetAllSale());

            UpdateCommandSal = new RelayCommand(parameter => UpdateSal());
            AddCommandSal = new RelayCommand(parameter => AddSal());
            RemoveCommandSal = new RelayCommand(parameter => RemoveSal());
        }

        public void UpdateSal()
        {
            // 1. Tjek om en sal er valgt
            if (SelectedSal == null) return;

            // 2. Opdater navnet på den valgte Sal
            SelectedSal.Name = Name;

            // 3. Gem ændringen i SalRepository
            _repo.UpdateSal(SelectedSal);

            // 4. Hvis sal skal knyttes til den valgte biograf
            if (_cinemaViewModel.SelectedCinema != null)
            {
                var cinema = _repoCinema.GetCinemaByName(_cinemaViewModel.SelectedCinema.Name);
                if (cinema != null)
                {
                    // Opdater listen i biografen, hvis den ikke allerede er tilføjet
                    if (!cinema.Sale.Contains(SelectedSal))
                    {
                        cinema.Sale.Add(SelectedSal);
                    }
                    _repoCinema.UpdateCinema(cinema);
                }
            }

            // 5. Tving UI til at genfriske visningen i ObservableCollection
            int index = Sale.IndexOf(SelectedSal);
            if (index >= 0)
            {
                Sale[index] = SelectedSal;
            }
        }

        public void AddSal()
        {
          
          
        }

        public void RemoveSal()
        {
            if (SelectedSal == null) return;

            _repo.RemoveSal(SelectedSal);
            Sale.Remove(SelectedSal);
        }
    }
}
