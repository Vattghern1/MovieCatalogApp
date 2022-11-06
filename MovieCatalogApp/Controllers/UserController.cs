﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models.Entities;
using MovieCatalogApp.Models;

namespace MovieCatalog.API.Controllers
{
    [Route("api/account/profile")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidateTokenService _validateTokenService;


        public UserController(IUserService userService, IValidateTokenService validateTokenService)
        {
            _userService = userService;
            _validateTokenService = validateTokenService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUserProfile()
        {
            if (_validateTokenService.ValidateToken(HttpContext.Request.Headers) == false)
            {
                return BadRequest("Token unavailable.");

            }
            return _userService.GetUserProfile(User.Identity.Name);
        }

        [HttpPut]
        [Authorize]
        public IActionResult PutUserProfile(ProfileModel updateProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation error.");
            }

            return _userService.PutUserProfile(updateProfile, User.Identity.Name);
        }
    }
}