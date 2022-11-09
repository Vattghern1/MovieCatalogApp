using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.DTOs
{
    public class ReviewShortModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Rating { get; set; }
    }
}
