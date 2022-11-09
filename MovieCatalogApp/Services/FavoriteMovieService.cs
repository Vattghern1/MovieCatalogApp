using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models.DTOs;
using MovieCatalog.API.Models.Entities;
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
            var user = _context.UsersProfiles
                .Include(c => c.FavoriteMovies)
                .ThenInclude(m => m.Genres)
                .Where(m => m.NickName == userName)
                .FirstOrDefault(l => l.NickName == userName);

            var favoriteMovies = user.FavoriteMovies;

            var movieElementList = new List<MovieElementModel>();
            
            foreach (var movie in favoriteMovies)
            {
                var movieElement = new MovieElementModel()
                {
                    MovieId = movie.MovieId,
                    Name = movie.Name,
                    Poster = movie.Poster,
                    Year = movie.Year,
                    Country = movie.Country,
                    Genres = GenreEntityToModel(movie.Genres),
                    Reviews = ReviewEntityToModel(movie)
                };
                movieElementList.Add(movieElement);
            };
            var favoriteMovesList = new MoviesListModel();
       

            return new JsonResult(movieElementList);
        }

        private List<ReviewShortModel> ReviewEntityToModel(MovieEntity movieEntity)
        {
            var review = _context.Reviews.Where(m => m.Movie.MovieId == movieEntity.MovieId).ToList();

            var shortReviewList = review.Select(review => new ReviewShortModel()
            {
                Id = review.ReviewId,
                Rating = review.Rating
            }).ToList();

            return shortReviewList;
        }

        private List<GenreModel> GenreEntityToModel(List<GenreDB> genres)
        {
            return genres.Select(i => new GenreModel()
            {
                Id = i.Id,
                Name = i.Name,
            }).ToList();
        }

        public JsonResult AddNewMovieToFavorites(string userName, Guid movieId)
        {
            var user = _context.UsersProfiles.Include(c=> c.FavoriteMovies).Where(user => user.NickName == userName).FirstOrDefault();
            var movie = _context.Movies.Where(movie => movie.MovieId == movieId).FirstOrDefault();
            
            foreach (var userFavoriteMovie in user.FavoriteMovies)
            {
                if (userFavoriteMovie.MovieId == movieId)
                {
                    throw new Exception("This movie already in your favotite movie list.");
                }
            }

            user.FavoriteMovies.Add(movie);
            _context.SaveChanges();
            
            return new JsonResult("Okey");
        }

        public JsonResult DeleteMovieFromFavorites(string userName, Guid movieId)
        {
            
            var user = _context.UsersProfiles.Include(c => c.FavoriteMovies).Where(user => user.NickName == userName).FirstOrDefault();
            var movie = _context.Movies.Where(movie => movie.MovieId == movieId).FirstOrDefault();

            foreach (var userFavoriteMovie in user.FavoriteMovies)
            {
                if (userFavoriteMovie.MovieId == movieId)
                {
                    user.FavoriteMovies.Remove(movie);
                    _context.SaveChanges();

                    return new JsonResult("Okey");
                }
            }
            throw new Exception("This movie not exist in your favorite movie list.");
        }
    }
}
