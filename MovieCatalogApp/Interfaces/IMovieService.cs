using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Interfaces
{
    public interface IMovieService
    {
        public JsonResult GetMoviesPage(string userName, int page, HttpContext context);
        public JsonResult GetMovieDetails(string userName, Guid id, HttpContext context);
    }
}
