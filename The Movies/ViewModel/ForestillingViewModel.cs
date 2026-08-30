using System;
using System.Collections.Generic;
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
    
        
        public ICommand AddForestilling { get; }
        public ICommand RemoveForestilling { get; }

        public ForestillingViewModel(IForestillingRepository repo)
        {
            _repo = repo;

        }





    }
}
