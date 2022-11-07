using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Controllers
{
    [Route("api​/movie​/{movieId}​/review​/")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IValidateTokenService _validateTokenService;

        public ReviewController(IReviewService reviewService, IValidateTokenService validateTokenService)
        {
            _reviewService = reviewService;
            _validateTokenService = validateTokenService;

        }
        [HttpPost("add")]
        [Authorize]
        public IActionResult AddReview(Guid movieId, ReviewModifyModel request)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _reviewService.AddNewReview(User.Identity.Name, movieId, request);
        }

        [HttpPut("{id}/edit")]
        [Authorize]
        public IActionResult EditReview(Guid movieId, Guid id, ReviewModifyModel request)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _reviewService.EditReview(User.Identity.Name, movieId, id, request);
        }

        [HttpDelete("{id}/delete")]
        [Authorize]
        public IActionResult DeleteReview(Guid movieId, Guid id)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (_validateTokenService.ValidateToken(accessToken) == false)
            {
                return BadRequest("Token unavailable.");
            }
            return _reviewService.DeleteReview(User.Identity.Name, movieId, id);
        }
    }
}
