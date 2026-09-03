using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using The_Movies.Model;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace The_Movies.Repository
{
   public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies = new List<Movie>();
        private const string FilePath = "movies.json";

        public MovieRepository()
        {
            LoadMovies();
        }
        // Create: Adds a new movie to the repository
        public void AddMovie(Movie movie)
        {
            if (GetMovieByTitle(movie.Title) != null)
            {
                throw new InvalidOperationException($"A movie with the title '{movie.Title}' already exists.");
            }
            _movies.Add(movie);
            SaveMovies();
        }

        // Read: Retrieves a movie by its title
        public Movie GetMovieByTitle(string title)
        {
            return _movies.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // Update: Updates an existing movie in the repository
        public void UpdateMovie(Movie movie)
        {
            var existingMovie = GetMovieByTitle(movie.Title);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Length = movie.Length;
                existingMovie.Genre = movie.Genre;
                SaveMovies();
            }
        }

        // Delete: Removes a movie from the repository
        public void RemoveMovie(Movie movie)
        {
            _movies.Remove(movie);
            SaveMovies();
        }

        // Retrieves all movies in the repository
        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }

        // Save movies to JSON file
        private void SaveMovies()
        {
            try
            {
                var options = new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    PropertyNamingPolicy = null,
                    PropertyNameCaseInsensitive = true,
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                };
                var json = JsonSerializer.Serialize(_movies, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving movies: {ex.Message}");
            }
        }

        private void LoadMovies()
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
                        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                    };
                    var loadedMovies = JsonSerializer.Deserialize<List<Movie>>(json, options);
                    if (loadedMovies != null)
                    {
                        _movies = loadedMovies;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading movies: {ex.Message}");
                _movies = new List<Movie>();
            }
        }
    }
}
