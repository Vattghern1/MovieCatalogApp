using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using MovieCatalogApp.Models;


namespace MovieCatalog.API.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation error.");
            }

            return _authService.Register(request);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginCredentials request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Validation error.");
            }

            return _authService.Login(request); 
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            
            if (User.Identity.Name == null)
            {
                return BadRequest("Name is null.");
            }

            return _authService.Logout(User.Identity.Name);

        }
    }
}
