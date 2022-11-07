using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Entities
{
    public class JSONWebToken
    {
        public Guid UserId { get; set; }

        [Key]
        public string Token { get; set; }
        

    }
}
