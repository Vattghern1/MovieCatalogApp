using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Entities;
using MovieCatalogApp.Models;


namespace MovieCatalog.API.Controllers
{
    [Route("api​/movies")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;


        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }

        [HttpGet("{page}")]
        [Authorize]
        public IActionResult GetMoviesPage(int page)
        {
            return _movieService.GetMoviesPage(User.Identity.Name, page);
        }
        

        [HttpGet("details/{id}")]
        [Authorize]
        public IActionResult GetMovieDetails(Guid id)
        {
           return  _movieService.GetMovieDetails(User.Identity.Name, id);
        }
        
        
    }
}
