using System.ComponentModel.DataAnnotations;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Models.DTOs
{
    public class MovieEntity
    {
        [Key]
        public Guid MovieId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public List<GenreDB>? Genres { get; set; } = new List<GenreDB>();
        public List<ProfileModel>? UsersLike { get; set; }
        public int Time { get; set; }
        public string? Tagline { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int? Budget { get; set; }
        public int? Fees { get; set; }
        public int AgeLimit { get; set; }

    }
}
