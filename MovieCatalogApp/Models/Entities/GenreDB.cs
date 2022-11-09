using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieCatalog.API.Models.Entities
{
    public class GenreDB
    {
               
        public Guid Id { get; set; }
        
        public string? Name { get; set; }

        public List<MovieEntity> Movies { get; set; }
        


    }
}
