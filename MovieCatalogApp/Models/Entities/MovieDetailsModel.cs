﻿using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Entities
{
    public class MovieDetailsModel
    {
        [Key]
        public Guid MovieId { get; set; }
        public string? Name { get; set; }
        public string? Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public GenreModel[]? Genres { get; set; }
        public ReviewModel[]? Reviews { get; set; }
        public int Time { get; set; }
        public string? Tagline { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int? Budget { get; set; }
        public int? Fees { get; set; }
        public int AgeLimit { get; set; }

    }
}