using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace The_Movies.Model.Repository
{
   public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }
        // Create: Adds a new movie to the repository
        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
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
            }
        }

        // Delete: Removes a movie from the repository
        public void RemoveMovie(Movie movie)
        {
            _movies.Remove(movie);
        }

        // Retrieves all movies in the repository
        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }
    }
}
