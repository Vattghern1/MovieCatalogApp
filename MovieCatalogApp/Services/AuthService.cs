﻿using MovieCatalogApp.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Interfaces;
using MovieCatalog.API.Models.DTOs;
using MovieCatalog.API.Models;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly Context _context;


        public AuthService(IConfiguration configuration, Context context)
        {
            _context = context;
            _configuration = configuration;
        }

        public JsonResult Register(UserRegisterModel request, HttpContext context)
        {

            var userNick = _context.UsersProfiles.Where(m => m.NickName == request.NickName).FirstOrDefault();
            var userEmail = _context.UsersProfiles.Where(m => m.Email == request.Email).FirstOrDefault();

            if (userNick != null && userNick.NickName != null)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                return new JsonResult("This Nickname is already taken.") ;
            }
            if (userEmail != null && userEmail.Email != null)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                return new JsonResult("This Email is already taken.");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new ProfileModel
            {
                UserId = Guid.NewGuid(),
                NickName = request.NickName,
                Name = request.Name,
                Email = request.Email,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                AvatarLink = null
            };

            var loginAndPasswords = new LoginsAndPasswordsOfUsers
            {
                NickName = request.NickName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "default"
            };



            _context.LoginsAndPasswords.Add(loginAndPasswords);
            _context.UsersProfiles.Add(user);
            _context.SaveChanges();

            var registerLoginCrenentials = new LoginCredentials
            {
                NickName = request.NickName,
                Password = request.Password
            };

            return Login(registerLoginCrenentials, context);
        }

        public JsonResult Login(LoginCredentials request, HttpContext context)
        {
            var identity = GetIdentity(request.NickName, request.Password);
            if (identity == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return new JsonResult("Invalid username or password.");
            }

            var loginUserProfile = _context.UsersProfiles.Where(m => m.NickName == request.NickName).FirstOrDefault();
            if (loginUserProfile == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return new JsonResult("User not found.");
            }

            var loginUserPasswords = _context.LoginsAndPasswords.Where(m => m.NickName == loginUserProfile.NickName).FirstOrDefault();
            if (!VerifyPasswordHash(request.Password, loginUserPasswords.PasswordHash, loginUserPasswords.PasswordSalt))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return new JsonResult("Wrong passwrod.");
            }
            
            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                issuer: JwtConfigurations.Issuer,
                audience: JwtConfigurations.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
                      
            _context.SaveChanges();

            return new JsonResult(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _context.LoginsAndPasswords.FirstOrDefault(x => x.NickName == username);
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.NickName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)

            };
        

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }


        public JsonResult Logout(string token, string userName, HttpContext context)
        {
            

            if (_context.JSONWebTokens.FirstOrDefault(m => m.Token == token) != null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return new JsonResult("Token is not valid.");
                
            }

            var user = _context.UsersProfiles.FirstOrDefault(m => m.NickName == userName);

            var newBadToken = new JSONWebToken
            {
                UserId = user.UserId,
                Token = token
            };

            _context.JSONWebTokens.Add(newBadToken);
            _context.SaveChanges();

            var response = new
            {
                token = "",
                message = "Logged Out"
            };
            return new JsonResult(response);
        }


        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

    }
}
