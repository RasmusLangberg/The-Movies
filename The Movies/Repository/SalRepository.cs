using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using The_Movies.Model;


namespace The_Movies.Repository
{
    public class SalRepository : ISalRepository
    {
        private List<Sal> _sale = new List<Sal>();
        private const string FilePath = "Sal.json";

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Converters = { new DateOnlyJsonConverter(), new TimeSpanJsonConverter() }
        };

        public SalRepository()
        {
            LoadSal();
        }

        public void AddSal(Sal sal)
        {
            _sale.Add(sal);
            SaveSal();
        }

        public IEnumerable<Sal> GetAllSale()
        {
            return _sale;
        }

        public Sal GetSalByName(string name)
        {
            return _sale.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateSal(Sal sal)
        {
            var exsistingSal = GetSalByName(sal.Name);

            if (exsistingSal != null)
            {
                exsistingSal.Name = sal.Name;
                
                
                SaveSal();
            };

        }

        public void RemoveSal(Sal sal)
        {
            _sale.Remove(sal);
            SaveSal();
        }

        private void SaveSal()
        {
            try
            {
                var json = JsonSerializer.Serialize(_sale, _jsonOptions);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving sal: {ex.Message}");
            }
        }

        private void LoadSal()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var loadedsale = JsonSerializer.Deserialize<List<Sal>>(json, _jsonOptions);
                    if (loadedsale != null)
                    {
                        _sale = loadedsale;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading sal: {ex.Message}");
                _sale = new List<Sal>();
            }
        }
    }
}
