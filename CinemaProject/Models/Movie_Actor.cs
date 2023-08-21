using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProject.Models
{
    public class Movie_Actor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Actor")]
        public int Actor_Id { get; set; }

        public virtual Actor Actor { get; set; }

        [ForeignKey("Movie")]
        public int Movie_Id { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
