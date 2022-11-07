using Microsoft.EntityFrameworkCore;

namespace MovieCatalog.API.Models.Entities
{
    [Keyless]
    public class MoviesListModel
    {

        public List<MovieElementModel>? Movie { get; set; }
    }
}
