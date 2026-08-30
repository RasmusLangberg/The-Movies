using System;
using System.Collections.Generic;
using System.Text;
using The_Movies.Model;

namespace The_Movies.Repository
{
    class CinemaRepository : ICinemaRepository

    {
        private List<Cinema> _cinmeas;

        public void AddCinema(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _cinmeas;
        }

        public Cinema GetCinemaByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveCinema(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public void UpdateCinema(Cinema cinema)
        {
            throw new NotImplementedException();
        }
    }
}

