using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models.DTOs;

namespace MovieCatalog.API.Models.Entities
{
    [Keyless]
    public class MoviesListModel
    {

        public List<MovieElementModel>? Movie { get; set; }
    }
}
