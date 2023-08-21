﻿namespace CinemaProject.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }

        public virtual List<Movie> Movies { get; set; }

    }
}
