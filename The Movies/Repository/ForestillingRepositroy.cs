using System;
using System.Collections.Generic;
using System.Text;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public class ForestillingRepositroy : IForestillingRepository
    {
        private const string FilePath = "Forestilling.json";

        public void AddForestilling(Forestilling forestilling)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forestilling> GetAllForestillinger()
        {
            throw new NotImplementedException();
        }

        public Forestilling GetForestillingByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveForestilling(Forestilling forestilling)
        {
            throw new NotImplementedException();
        }

        public void UpdateForestilling(Forestilling forestilling)
        {
            throw new NotImplementedException();
        }
    }
}
