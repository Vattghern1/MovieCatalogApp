using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Interfaces;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Services
{
    public class FavoriteMovieService : IFavoriteMovieService
    {
        private readonly Context _context;
        public FavoriteMovieService(Context context)
        {
            _context = context;
        }

        public JsonResult GetFavoriteMovies(string userName)
        {
            return new JsonResult(userName);
        }

        public JsonResult AddNewMovieToFavorites(string userName, Guid movieId)
        {
            return new JsonResult(userName);
        }

        public JsonResult DeleteMovieFromFavorites(string userName, Guid movieId)
        {
            return new JsonResult(userName);
        }
    }
}
