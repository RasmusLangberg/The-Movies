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

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Converters = { new DateOnlyJsonConverter(), new TimeSpanJsonConverter() }
        };

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
                var json = JsonSerializer.Serialize(_cinemas, _jsonOptions);
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
                    var loadedCinema = JsonSerializer.Deserialize<List<Cinema>>(json, _jsonOptions);
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

