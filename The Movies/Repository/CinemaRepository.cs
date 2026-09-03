using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public class CinemaRepository : ICinemaRepository

    {
        private List<Cinema> _cinemas = new List<Cinema>();
        private const string FilePath = "Cinema.json";

        public CinemaRepository()
        {
            LoadCinema();
        }
        public void AddCinema(Cinema cinema)
        {
            _cinemas.Add(cinema);
            SaveCinema();
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _cinemas;
        }

        public Cinema GetCinemaByName(string name)
        {
            return _cinemas.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveCinema(Cinema cinema)
        {
            _cinemas.Remove(cinema);
            SaveCinema();
        }

        public void UpdateCinema(Cinema cinema)
        {
            var excist = GetCinemaByName(cinema.Name);

            if(excist != null)
            {
                excist.Name = cinema.Name;
                excist.Sale = cinema.Sale;
                SaveCinema();
            }
        }

        private void SaveCinema()
        {
            try
            {
                var options = new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    PropertyNamingPolicy = null,
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var json = JsonSerializer.Serialize(_cinemas, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cinemas: {ex.Message}");
            }
        }

        private void LoadCinema()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var options = new JsonSerializerOptions 
                    { 
                        PropertyNamingPolicy = null,
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() }
                    };
                    var loadedCinema = JsonSerializer.Deserialize<List<Cinema>>(json, options);
                    if (loadedCinema != null)
                    {
                        _cinemas = loadedCinema;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading cinemas: {ex.Message}");
                _cinemas = new List<Cinema>();
            }
        }

    }
}

