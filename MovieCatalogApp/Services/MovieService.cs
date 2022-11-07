using MovieCatalogApp.Models;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using Microsoft.EntityFrameworkCore;

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
            var moviesPageList = new MoviesPagedListModel()
            {
                PageInfo =
                {
                    PageCount = 6,
                    PageSize = 6,
                    CurrentPage = page
                },

                Movies = null,
                
            };

            return new JsonResult(moviesPageList);
        }

        public JsonResult GetMovieDetails(string userName, Guid id)
        {
            var requestedMovie = _context.MovieDetailsModels.Where(m => m.MovieId == id)
                    .Include(u => u.Genres).Include(c => c.Reviews)
                    .ToList();
                    

            if (requestedMovie == null)
            {
                throw new Exception("Movie not found.");
            }

            return new JsonResult(requestedMovie);
        }
    }
}
