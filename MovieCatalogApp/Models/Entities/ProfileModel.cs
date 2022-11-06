using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Entities
{
    public class ProfileModel
    {
        [Key]
        public Guid UserId { get; set; }
        public string? NickName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? AvatarLink { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

    }
}
