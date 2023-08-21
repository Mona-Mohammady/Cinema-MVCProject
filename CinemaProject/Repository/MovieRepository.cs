using CinemaProject.Data;
using CinemaProject.Models;
using CinemaProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Repository
{
    public class MovieRepository:IMovieRepository
    {
        AppDBContext context;

        public MovieRepository(AppDBContext context)
        {
            this.context = context;
        }
        public List<Movie> GetAll()
        {


            return context.Movies.Include(c=>c.Cinema).ToList();
        }
        public Movie GetById(int id)
        {
            return context.Movies.FirstOrDefault(d => d.Id == id);
        }
        public Movie GetByName(string name)
        {
            return context.Movies.FirstOrDefault(d => d.Name == name);
        }
        public void Add(Movie movie)
        {
            context.Movies.Add(movie);
        }
        public void Save()
        {

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Movie oldmov = GetById(id);
            // oldemp.IsDeleted = true;
            context.Movies.Remove(oldmov);


        }
        public void Update(Movie movie, int id)
        {
            Movie oldmov = context.Movies.SingleOrDefault(d => d.Id == id);
            oldmov.Id = id;
            oldmov.Name = movie.Name;
            oldmov.Price = movie.Price;
            oldmov.Description = movie.Description;

        }

        public List<Movie> Search(string Name)
        {
            var movieSearch= context.Movies.Include(c=>c.Cinema).Where(n => n.Name.ToLower().Contains(Name.ToLower())).ToList();
            return movieSearch;
        }
    }
}

