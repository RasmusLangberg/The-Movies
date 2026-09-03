using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;
using The_Movies.Model;

namespace The_Movies.Repository
{
   public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies = new List<Movie>();
        private const string FilePath = "movies.json";

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Converters = { new DateOnlyJsonConverter(), new TimeSpanJsonConverter() }
        };

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
            var json = JsonSerializer.Serialize(_movies, _jsonOptions);
            File.WriteAllText(FilePath, json);
        }

        // Load movies from JSON file
        private void LoadMovies()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var loadedMovies = JsonSerializer.Deserialize<List<Movie>>(json, _jsonOptions);
                    if (loadedMovies != null)
                    {
                        _movies = loadedMovies;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                _movies = new List<Movie>();
            }
        }
    }
}
