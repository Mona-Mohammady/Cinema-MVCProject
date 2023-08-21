using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models
{
    public class Cinema
    {

        public int Id { get; set; }
        
        public string C_Name { get; set; }
        public string Desc { get; set; }
        public string Logo { get; set; }

        public virtual List<Movie> Movies { get; set; }


    }
}
