using System;
using System.Collections.Generic;
using System.Text;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public interface ISalRepository
    {

        void AddSal(Sal sal);
        IEnumerable<Sal> GetAllSale();
        Sal GetSalByName(string name);
        void UpdateSal(Sal sal);
        void RemoveSal(Sal sal);
    }
}
