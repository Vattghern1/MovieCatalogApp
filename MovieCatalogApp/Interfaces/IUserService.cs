using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models.Entities;

namespace MovieCatalog.API.Interfaces
{
    public interface IUserService
    {
        public JsonResult GetUserProfile(string userName);
        public JsonResult PutUserProfile(ProfileModel updateProfile, string userName);
    }
}
