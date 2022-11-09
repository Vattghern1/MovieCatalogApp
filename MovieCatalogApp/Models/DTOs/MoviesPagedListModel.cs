namespace MovieCatalog.API.Models.DTOs
{
    public class MoviesPagedListModel
    {
        public List<MovieElementModel>? Movies { get; set; }
        public PageInfoModel? PageInfo { get; set; }

    }
}
