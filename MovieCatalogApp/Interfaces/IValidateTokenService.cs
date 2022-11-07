namespace MovieCatalog.API.Interfaces
{
    public interface IValidateTokenService
    {
        public bool ValidateToken(string token);
    }
}
