using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Entities
{
    public class LoginsAndPasswordsOfUsers
    {
        [Key]
        public string NickName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}
