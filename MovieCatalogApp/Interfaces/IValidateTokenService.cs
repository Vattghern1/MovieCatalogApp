namespace MovieCatalog.API.Interfaces
{
    public interface IValidateTokenService
    {
        public bool ValidateToken(IHeaderDictionary token);
    }
}
