using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Controllers
{
    [Route("api​/movie​/{movieId}​/review​/")]
    [ApiController]
    public class ReviewController : Controller
    {
        [HttpPost("add")]
        public string addReview()
        {
            return "add Review";
        }

        [HttpPut("{id}/edit")]
        public ReviewModifyModel editReview(ReviewModifyModel newReviewModifyModel)
        {
            return newReviewModifyModel;
        }

        [HttpDelete("{id}/delete")]
        public string deleteReview()
        {
            return "delete Review";
        }
    }
}
