using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.Repository;
using The_Movies.ViewModel;


namespace The_Movies.Repository
{
    public class SalRepository : ISalRepository
    {
        private List<Sal> _sale = new List<Sal>();
        private const string FilePath = "Sal.json";

        public SalRepository()
        {
            LoadSal();
        }

        public void AddSal(Sal sal)
        {
            _sale.Add(sal);    
        }

        public IEnumerable<Sal> GetAllSale()
        {
            return _sale;
        }

        public Sal GetSalByName(string name)
        {
           return _sale.Find(x => name.Equals(name));
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
        }

        private void SaveSal()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(_sale, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        private void LoadSal()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var loadedsale = JsonSerializer.Deserialize<List<Sal>>(json);
                    if (loadedsale != null)
                    {
                        _sale = loadedsale;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                _sale = new List<Sal>();
            }
        }
    }
}
