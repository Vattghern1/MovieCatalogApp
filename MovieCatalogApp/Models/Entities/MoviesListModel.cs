using Microsoft.EntityFrameworkCore;

namespace MovieCatalog.API.Models.Entities
{
    [Keyless]
    public class MoviesListModel
    {
        public MovieElementModel? Movie { get; set; }
    }
}
