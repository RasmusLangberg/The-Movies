using System;
using System.Collections.Generic;
using System.Text;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public interface ICinemaRepository
    {
        void AddCinema(Cinema cinema);
        IEnumerable<Cinema> GetAllCinemas();
        Cinema GetCinemaByName(string name);
        void UpdateCinema(Cinema cinema);
        void RemoveCinema(Cinema cinema);

    }
}
