using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models.DTOs;
using System.ComponentModel.DataAnnotations;


namespace MovieCatalog.API.Models.Entities
{
    public class GenreModel
    {

        public Guid Id { get; set; }

        public string? Name { get; set; }
    }
}
