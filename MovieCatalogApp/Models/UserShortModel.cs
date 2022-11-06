using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models
{
    public class UserShortModel
    {
        [Key]
        public Guid UserId { get; set; }
        public string? NickName { get; set; }
        public string? Avatar { get; set; }

    }
}
