using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly Context _context;
        public ReviewService(Context context)
        {
            _context = context;
        }

        public JsonResult AddNewReview(string userName, Guid movieId, ReviewModifyModel requestReview)
        {
            return new JsonResult(userName);
        }

        public JsonResult EditReview(string userName, Guid movieId, Guid reviewId, ReviewModifyModel requestReview)
        {
            return new JsonResult(userName);
        }

        public JsonResult DeleteReview(string userName, Guid movieId, Guid reviewId)
        {
            return new JsonResult(userName);
        }


    }
}
