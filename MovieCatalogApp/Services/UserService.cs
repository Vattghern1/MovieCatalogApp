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

        public JsonResult GetUserProfile(string userName)
        {
            var requestedProfile = _context.ProfileModels.Where(m => m.NickName == userName).FirstOrDefault();
            if (requestedProfile == null)
            {
                throw new Exception("Profile not found");
            }

            return new JsonResult(requestedProfile);
        }

        public JsonResult PutUserProfile(ProfileModel updateProfile, string userName)
        {
          
            if (_context.ProfileModels.FirstOrDefault(m => m.Email == updateProfile.Email && m.UserId != updateProfile.UserId) != null)
            {
                throw new Exception("This email address is already in use by another person.");
            }
            

            var userProfile = _context.ProfileModels.Where(m => m.UserId == updateProfile.UserId).FirstOrDefault();

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
