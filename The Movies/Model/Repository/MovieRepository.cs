using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace The_Movies.Model.Repository
{
   public class MovieRepository
    {
        private List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }
        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }
        public void RemoveMovie(Movie movie)
        {
            _movies.Remove(movie);
        }
        public List<Movie> GetAllMovies()
        {
            return _movies;
        }
    }
}
