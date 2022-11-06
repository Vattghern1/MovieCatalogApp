using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Models
{
    public class MoviesPagedListModel
    {
        public MovieElementModel[]? Movies { get; set; }
        public PageInfoModel? PageInfo { get; set; }

    }
}
