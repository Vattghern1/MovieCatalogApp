using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models.Entities;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Controllers
{
    [Route("api​/favorites")]
    [ApiController]
    public class FavotireMoviesController : ControllerBase
    {
        [HttpGet]
        public MoviesListModel GetFavoriteMovies(MoviesListModel newMoviesListModel)
        {
            return newMoviesListModel;
        }

        [HttpPost("{id}/add")]
        public string addFavoriteMovie()
        {
            return "add Favorite Movie";
        }

        [HttpDelete("{id}/delete")]
        public string deleteFavoriteMovie()
        {
            return "delete Favorite Movie";
        }

    }
}
