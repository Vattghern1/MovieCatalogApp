using MovieCatalogApp.Models;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.API.Services
{
    public class UserService : IUserService
    {
        private readonly Context _context;     
        public UserService(Context context)
        {
            _context = context;
        }

        public JsonResult GetUserProfile(string userName, HttpContext context)
        {
            var requestedProfile = _context.UsersProfiles.Where(m => m.NickName == userName).FirstOrDefault();
            if (requestedProfile == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return new JsonResult("Profile not found.");
            }

            return new JsonResult(requestedProfile);
        }

        public JsonResult PutUserProfile(ProfileModel updateProfile, string userName, HttpContext context)
        {
          
            if (_context.UsersProfiles.FirstOrDefault(m => m.Email == updateProfile.Email && m.UserId != updateProfile.UserId) != null)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                return new JsonResult("This email address is already in use by another person.");
            }
            

            var userProfile = _context.UsersProfiles.Where(m => m.UserId == updateProfile.UserId).FirstOrDefault();

            userProfile.Name = updateProfile.Name;
            userProfile.Email = updateProfile.Email;
            userProfile.AvatarLink = updateProfile.AvatarLink;
            userProfile.BirthDate = updateProfile.BirthDate;
            userProfile.Gender = updateProfile.Gender;

            _context.SaveChanges();
            return new JsonResult(userProfile);
        }
    }
}
