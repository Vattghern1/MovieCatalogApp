using System.ComponentModel.DataAnnotations;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Models.DTOs
{
    public class MovieElementModel
    {
        [Key]
        public Guid MovieId { get; set; }
        public string? Name { get; set; }
        public string? Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public List<GenreModel>? Genres { get; set; }
        public List<ReviewShortModel>? Reviews { get; set; }
    }
}
