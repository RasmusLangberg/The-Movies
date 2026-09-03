using The_Movies.Model;

namespace The_Movies.Repository
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
