using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.DTOs;
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
            var user = _context.UsersProfiles.FirstOrDefault(user => user.NickName == userName);
            var movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == movieId);

            var checker = _context.Reviews.Where(m => m.Movie == movie && m.User == user);

            if (checker != null)
            {
                throw new Exception("This user already have review on this movie.");
            }


            var newReview = new ReviewEntity()
            {
                ReviewId = Guid.NewGuid(),
                Rating = requestReview.Rating,
                ReviewText = requestReview.ReviewText,
                IsAnonymous = requestReview.IsAnonymous,
                CreateDateTime = DateTime.Now,
                User = user,
                Movie = movie
            };

            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return new JsonResult("Okey.");
        }

        public JsonResult EditReview(string userName, Guid movieId, Guid reviewId, ReviewModifyModel requestReview)
        {

            var user = _context.UsersProfiles.FirstOrDefault(user => user.NickName == userName);
            var movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == movieId);

            var review = _context.Reviews.Where(m => m.Movie == movie && m.User == user).FirstOrDefault();

            if (review == null)
            {
                throw new Exception("Review not exist.");
            };

            if (review.User != user)
            {
                throw new Exception("You cannot edit someone else's review.");
            };


            review.Rating = requestReview.Rating;
            review.ReviewText = requestReview.ReviewText;
            review.IsAnonymous = requestReview.IsAnonymous;
             

            _context.SaveChanges();

            return new JsonResult("Okey");
        }

        public JsonResult DeleteReview(string userName, Guid movieId, Guid reviewId)
        {
            var user = _context.UsersProfiles.FirstOrDefault(user => user.NickName == userName);
            var movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == movieId);

            var review = _context.Reviews.Where(m => m.Movie == movie && m.User == user).FirstOrDefault();

            if (review == null)
            {
                throw new Exception("Review not exist.");
            };

            if (review.User != user)
            {
                throw new Exception("You cannot edit someone else's review.");
            };

            _context.Reviews.Remove(review);
            _context.SaveChanges();

            return new JsonResult("Okey");
        }

        

        


    }
}
