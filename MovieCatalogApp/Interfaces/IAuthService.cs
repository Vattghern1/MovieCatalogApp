using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Services;
using MovieCatalog.API.Models.DTOs;

namespace MovieCatalog.API.Interfaces
{
    public interface IAuthService
    {
        public JsonResult Register(UserRegisterModel request);
        public JsonResult Login(LoginCredentials request);
        public JsonResult Logout(string? token, string userNick);

    }
}
