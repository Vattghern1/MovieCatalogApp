using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Entities
{
    public class MovieElementModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public GenreModel[]? Genres { get; set; }
        public ReviewShortModel[]? Reviews { get; set; }
    }
}
