using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public class ForestillingRepositroy : IForestillingRepository
    {
        private List<Forestilling> _fore = new List<Forestilling>();
        private const string FilePath = "Forestilling.json";

        public ForestillingRepositroy()
        {
            LoadFore();
        }

        public void AddForestilling(Forestilling forestilling)
        {
            _fore.Add(forestilling);
            SaveFore();
        }

        public IEnumerable<Forestilling> GetAllForestillinger()
        {
            return _fore;
        }

        public Forestilling GetForestillingByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveForestilling(Forestilling forestilling)
        {
            _fore.Remove(forestilling);
            SaveFore();
        }

        public void UpdateForestilling(Forestilling forestilling)
        {
            var existingForestilling = _fore.Find(f => f.StartTid == forestilling.StartTid);
            if (existingForestilling != null)
            {
                existingForestilling.Movie = forestilling.Movie;
                existingForestilling.Cinema = forestilling.Cinema;
                existingForestilling.Sal = forestilling.Sal;
                existingForestilling.StartTid = forestilling.StartTid;
                SaveFore();
            }
        }


        private void SaveFore()
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
                var json = JsonSerializer.Serialize(_fore, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving forestillinger: {ex.Message}");
            }
        }

        private void LoadFore()
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
                    var loadedFore = JsonSerializer.Deserialize<List<Forestilling>>(json, options);
                    if (loadedFore != null)
                    {
                        _fore = loadedFore;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading forestillinger: {ex.Message}");
                _fore = new List<Forestilling>();
            }
        }



    }
}
