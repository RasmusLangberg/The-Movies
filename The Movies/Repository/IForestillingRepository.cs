using System;
using System.Collections.Generic;
using System.Text;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public interface IForestillingRepository
    {
        void AddForestilling(Forestilling forestilling);
        IEnumerable<Forestilling> GetAllForestillinger();
        Forestilling GetForestillingByName(string name);
        void UpdateForestilling(Forestilling forestilling);
        void RemoveForestilling(Forestilling forestilling   );
    }
}
