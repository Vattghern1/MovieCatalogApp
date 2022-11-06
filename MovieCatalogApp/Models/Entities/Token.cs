using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Entities
{
    [Keyless]
    public class Token
    {
        [Required]
        public string token { get; set; }
    }
}
