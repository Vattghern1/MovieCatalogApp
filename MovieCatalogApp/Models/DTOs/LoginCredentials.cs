using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.DTOs
{
    public class LoginCredentials
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
