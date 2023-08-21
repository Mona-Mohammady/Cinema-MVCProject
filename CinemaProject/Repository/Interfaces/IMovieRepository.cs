using CinemaProject.Models;

namespace CinemaProject.Repository.Interfaces
{
    public interface IMovieRepository
    {
        public List<Movie> GetAll();

        public Movie GetById(int id);

        public Movie GetByName(string name);

        public void Add(Movie movie);


        public void Save();

        public void Delete(int id);

        public void Update(Movie movie, int id);

        List<Movie> Search(string Name);
    }
}
