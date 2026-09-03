using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using The_Movies.Model;

namespace The_Movies.Repository
{
    public class ForestillingRepositroy : IForestillingRepository
    {
        private List<Forestilling> _fore = new List<Forestilling>();
        private const string FilePath = "Forestilling.json";

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Converters = { new DateOnlyJsonConverter(), new TimeSpanJsonConverter() }
        };

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
            throw new NotImplementedException();
        }


        private void SaveFore()
        {
            try
            {
                var json = JsonSerializer.Serialize(_fore, _jsonOptions);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        // Load movies from JSON file
        private void LoadFore()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var loadedFore = JsonSerializer.Deserialize<List<Forestilling>>(json, _jsonOptions);
                    if (loadedFore != null)
                    {
                        _fore = loadedFore;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                _fore = new List<Forestilling>();
            }
        }



    }
}
