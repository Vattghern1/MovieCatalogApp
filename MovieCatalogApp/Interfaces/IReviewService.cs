using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Interfaces
{
    public interface IReviewService
    {
        public JsonResult AddNewReview(string userName, Guid movieId, ReviewModifyModel requestReview);
        public JsonResult EditReview(string userName, Guid movieId, Guid reviewId, ReviewModifyModel requestReview);
        public JsonResult DeleteReview(string userName, Guid movieId, Guid reviewId);

    }
}
