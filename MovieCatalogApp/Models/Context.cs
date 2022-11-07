using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalogApp.Models
{
    public class Context : DbContext
    {
        public DbSet<MovieDetailsModel>? MovieDetailsModels { get; set; }
        public DbSet<ProfileModel>? ProfileModels { get; set; }
        public DbSet<ReviewModel>? ReviewModels { get; set; }
        public DbSet<JSONWebToken>? JSONWebTokens { get; set; }
        public DbSet<LoginsAndPasswordsOfUsers>? LoginsAndPasswords { get; set; }
       // public DbSet<MoviesListModel>? Movies { get; set; }
      

        public Context(DbContextOptions<Context> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
