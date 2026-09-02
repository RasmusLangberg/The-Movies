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

        public ObservableCollection<Sal> Sale { get; set; }

        public ICommand AddCommandSal;

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



        private Cinema _cinema;

        public Cinema Cinema
        {
            get { return _cinema; }
            set { _cinema = value; OnPropertyChanged(nameof(Cinema)); }
        }




        public SalViewModel(ISalRepository repo)
        {
            _repo = repo;

            AddCommandSal = new RelayCommand(parameter => AddSal());
            RemoveCommandSal = new RelayCommand(parameter => RemoveSal());

        }


        public void AddSal()
        {

            Sal sal = new Sal(Name, AntalSæder, Cinema);
            _repo.AddSal(sal);


        }

        public void RemoveSal()
        {

            _repo.RemoveSal(SelectedSal);

        }
    }
}
