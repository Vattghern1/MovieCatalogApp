using System.ComponentModel.DataAnnotations;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Models.DTOs
{
    public class MovieDetailsModel
    {
        [Key]
        public Guid MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public List<GenreModel>? Genres { get; set; }
        public List<ReviewModel>? Reviews { get; set; }
        public int Time { get; set; }
        public string? Tagline { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int? Budget { get; set; }
        public int? Fees { get; set; }
        public int AgeLimit { get; set; }

    }
}
