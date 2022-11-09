using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieCatalog.API.Models.DTOs;
using MovieCatalog.API.Models.Entities;
using System.Runtime.InteropServices;


namespace MovieCatalogApp.Models
{
    public class Context : DbContext
    {
        public DbSet<MovieEntity>? Movies { get; set; }
        public DbSet<ProfileModel>? UsersProfiles { get; set; }
        public DbSet<JSONWebToken>? JSONWebTokens { get; set; }
        public DbSet<ReviewEntity>? Reviews { get; set; }
        public DbSet<LoginsAndPasswordsOfUsers>? LoginsAndPasswords { get; set; } 


        public Context(DbContextOptions<Context> options): base(options)
        {
            
            Database.EnsureCreated();
        }   
        


    }
}
