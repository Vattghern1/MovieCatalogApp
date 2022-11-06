using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models
{
    public class ReviewShortModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Rating { get; set; }
    }
}
