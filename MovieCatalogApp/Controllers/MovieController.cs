using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Net.Http.Headers;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.DTOs;
using MovieCatalog.API.Models.Entities;
using MovieCatalogApp.Models;


namespace MovieCatalog.API.Controllers
{
    [Route("api​/movies")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IValidateTokenService _validateTokenService;

        private readonly Context _context;


        public MovieController(IMovieService movieService, IValidateTokenService validateTokenService, Context context)
        {
            _movieService = movieService;
            _validateTokenService = validateTokenService;
            _context = context;
        }

        [HttpGet("{page}")]
        [Authorize]
        public IActionResult GetMoviesPage(int page)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _movieService.GetMoviesPage(User.Identity.Name, page);
        }
        

        [HttpGet("details/{id}")]
        [Authorize]
        public IActionResult GetMovieDetails(Guid id)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return  _movieService.GetMovieDetails(User.Identity.Name, id);
        }
    }
}
