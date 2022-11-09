using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models.Entities;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Controllers
{
    [Route("api​/favorites")]
    [ApiController]
    public class FavotireMoviesController : ControllerBase
    {
        private readonly IFavoriteMovieService _favoriteMovieService;
        private readonly IValidateTokenService _validateTokenService;

        public FavotireMoviesController(IFavoriteMovieService favoriteMovieService, IValidateTokenService validateTokenService)
        {
            _validateTokenService = validateTokenService;
            _favoriteMovieService = favoriteMovieService;

        }
        [HttpGet]
        [Authorize]
        public IActionResult GetFavoriteMovies()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _favoriteMovieService.GetFavoriteMovies(User.Identity.Name);
        }

        [HttpPost("{id}/add")]
        [Authorize]
        public IActionResult AddFavoriteMovie(Guid id)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _favoriteMovieService.AddNewMovieToFavorites(User.Identity.Name, id);
        }

        [HttpDelete("{id}/delete")]
        [Authorize]
        public IActionResult DeleteFavoriteMovie(Guid id)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _favoriteMovieService.DeleteMovieFromFavorites(User.Identity.Name, id);
        }

    }
}
