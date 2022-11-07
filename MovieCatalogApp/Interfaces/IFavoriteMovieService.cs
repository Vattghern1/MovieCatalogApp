using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Interfaces
{
    public interface IFavoriteMovieService
    {
        public JsonResult GetFavoriteMovies(string userName);
        public JsonResult AddNewMovieToFavorites(string userName, Guid movieId);
        public JsonResult DeleteMovieFromFavorites(string userName, Guid movieId);
    }
}
