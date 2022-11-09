using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.DTOs
{
    public class UserShortModel
    {
        public Guid UserId { get; set; }
        public string? NickName { get; set; }
        public string? Avatar { get; set; }

    }
}
