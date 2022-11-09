using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models
{
    public class ReviewModifyModel
    {
        [Required]
        public string? ReviewText { get; set; }
        [Range(0,10)]
        public int Rating { get; set; }
        public bool IsAnonymous { get; set; }

    }
}
