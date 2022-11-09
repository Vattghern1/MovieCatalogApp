using MovieCatalog.API.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MovieCatalog.API.Models.DTOs
{
    public class ReviewEntity
    {
        [Key]
        public Guid ReviewId { get; set; }       
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreateDateTime { get; set; }
        [Required]
        public virtual ProfileModel User { get; set; }
        [Required]
        public virtual MovieEntity Movie { get; set; }
        
    }
}
