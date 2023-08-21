using CinemaProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProject.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MovieCategory movieCategory { get; set; }

        // Relationships

        [ForeignKey("Producer")]
        public int Producer_Id { get; set; }

        public virtual Producer Producer { get; set; }

        [ForeignKey("Cinema")]
        public int Cinema_Id { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual List<Movie_Actor> Movie_Actors { get; set; }

    }
}
