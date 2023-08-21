using CinemaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }

        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }

        public virtual DbSet<Movie_Actor> Movie_Actors { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Cinema;Integrated Security=True;TrustServerCertificate=True");
        //}
    }
}
