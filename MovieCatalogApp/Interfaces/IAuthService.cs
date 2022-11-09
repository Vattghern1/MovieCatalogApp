using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Services;
using MovieCatalog.API.Models.DTOs;

namespace MovieCatalog.API.Interfaces
{
    public interface IAuthService
    {
        public JsonResult Register(UserRegisterModel request, HttpContext context);
        public JsonResult Login(LoginCredentials request, HttpContext context);
        public JsonResult Logout(string? token, string userNick, HttpContext context);

    }
}
