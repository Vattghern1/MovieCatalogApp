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
            var newUserEmail = _context.ProfileModels.Where(m => m.Email == updateProfile.Email).FirstOrDefault();

            if (newUserEmail.Email != null && newUserEmail.UserId != updateProfile.UserId)
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
