using System;
using System.Collections.Generic;
using System.Text;

namespace The_Movies.Model.Repository
{
    public interface IMovieRepository
    {
       
        void AddMovie(Movie movie);
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieByTitle(string title);
        void UpdateMovie(Movie movie);
        void RemoveMovie(Movie movie);

    }
}
