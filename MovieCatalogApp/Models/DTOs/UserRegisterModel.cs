using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.DTOs
{
    public class UserRegisterModel
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
