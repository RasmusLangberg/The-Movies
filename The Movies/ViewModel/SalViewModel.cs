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
    public class SalViewModel
    {

        private readonly ISalRepository _repo;

        public ObservableCollection<Sal> Sale { get; set; }

        public ICommand AddCommandSal;

        public ICommand RemoveCommandSal;



        public SalViewModel(ISalRepository repo)
        {
            _repo = repo;

            AddCommandSal = new RelayCommand(parameter => AddSal());
            RemoveCommandSal = new RelayCommand(parameter => RemoveSal());

        }


        public void AddSal()
        {

            Sal sal = new Sal();
            _repo.AddSal(sal);


        }

        public void RemoveSal()
        {


        }
    }
}
