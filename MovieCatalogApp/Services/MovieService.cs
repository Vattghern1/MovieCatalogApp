﻿using MovieCatalogApp.Models;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models.DTOs;

namespace MovieCatalog.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly Context _context;
        public MovieService(Context context)
        {
            _context = context;
        }

        public JsonResult GetMoviesPage(string userName, int page)
        {   
            
            var requestedMovies = _context.Movies
                .Include(movie => movie.Genres)
                .Skip((page * 6) - 6)
                .Take(6)
                .ToList();

            List<MovieElementModel> movieOnPage = new();
            foreach (var movieElement in requestedMovies)
            {
                List<GenreModel> requestedGenres = new();
                foreach (var genre in movieElement.Genres)
                {
                    var Genre = new GenreModel()
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    };
                    requestedGenres.Add(Genre);
                };

                List<ReviewShortModel> reviews = new();

                var reviewFromDB = _context.Reviews.Where(review => review.Movie == movieElement).Include(review => review.Movie).ToList();

                foreach (var review in reviewFromDB)
                {
                    var Review = new ReviewShortModel()
                    {
                        Id = review.ReviewId,
                        Rating = review.Rating,
                    };
                    reviews.Add(Review);
                };

                var requestedMovie = new MovieElementModel()
                {
                    MovieId = movieElement.MovieId,
                    Name = movieElement.Name,
                    Poster = movieElement.Poster,
                    Year = movieElement.Year,
                    Country = movieElement.Country,
                    Genres = requestedGenres,
                    Reviews = reviews


                };
                movieOnPage.Add(requestedMovie);               
                
            };

            var moviesPageList = new MoviesPagedListModel()
            {
                PageInfo = new PageInfoModel()
                {
                    PageCount = (int)5,
                    PageSize = (int)6,
                    CurrentPage = (int)page
                },

                Movies = movieOnPage,
            };

            return new JsonResult(moviesPageList);
        }

        public JsonResult GetMovieDetails(string userName, Guid id)
        {
            var requestedMovie = _context.Movies
                    .Include(movie => movie.Genres)
                    .Where(m => m.MovieId == id)
                    .FirstOrDefault();

            List<GenreModel> requestedGenres = new();
            foreach (var genre in requestedMovie.Genres)
            {
                var Genre = new GenreModel()
                {
                    Id = genre.Id,
                    Name = genre.Name
                };
                requestedGenres.Add(Genre);
            };

            var requestedMovieDetails = new MovieDetailsModel()
            {
                MovieId = requestedMovie.MovieId,
                Name = requestedMovie.Name,
                Poster = requestedMovie.Poster,
                Year = requestedMovie.Year,
                Country = requestedMovie.Country,
                Time = requestedMovie.Time,
                Tagline = requestedMovie.Tagline,
                Description = requestedMovie.Description,
                Director = requestedMovie.Director,
                Budget = requestedMovie.Budget,
                Fees = requestedMovie.Fees,
                AgeLimit = requestedMovie.AgeLimit,
                Genres = requestedGenres

            };


            if (requestedMovie == null)
            {
                throw new Exception("Movie not found.");
            }

            return new JsonResult(requestedMovieDetails);
        }
    }
}
