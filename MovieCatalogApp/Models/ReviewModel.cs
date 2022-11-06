using System.Data;

namespace MovieCatalog.API.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreateDateTime { get; set; }
        public UserShortModel? Author { get; set; }
    }
}
