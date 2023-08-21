using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 25 chars")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Biography is required")]

        public string Bio { get; set; }
        public string Image { get; set; }

        public virtual List<Movie_Actor> Movie_Actors { get; set; }

    }
}
