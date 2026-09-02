using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using The_Movies.Model;

namespace The_Movies.Repository
{
    class CinemaRepository : ICinemaRepository

    {
        private List<Cinema> _cinemas = new List<Cinema>();
        private const string FilePath = "Sal.json";

        public void AddCinema(Cinema cinema)
        {
            _cinemas.Add(cinema);
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _cinemas;
        }

        public Cinema GetCinemaByName(string name)
        {
            return _cinemas.Find(x => name.Equals(name));
        }

        public void RemoveCinema(Cinema cinema)
        {
            _cinemas.Remove(cinema);
        }

        public void UpdateCinema(Cinema cinema)
        {
            var excist = GetCinemaByName(cinema.Name);

            if(excist != null)
            {
                excist.Name = cinema.Name;
                excist.Sale = cinema.Sale;
                SaveSal();
            }
        }

        private void SaveSal()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(_cinemas, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }



    }
}

