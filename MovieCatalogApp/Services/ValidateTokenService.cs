﻿using MovieCatalogApp.Models;
using MovieCatalog.API.Models.Entities;
using MovieCatalog.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.API.Services
{
    public class ValidateTokenService : IValidateTokenService
    {
        private readonly Context _context;
        public ValidateTokenService(Context context)
        {
            _context = context;
        }
        public bool ValidateToken(string token)
        {
            var requstedToken = _context.JSONWebTokens.Where(m => m.Token == token).FirstOrDefault();
            if (requstedToken != null)
            {
                return false;
            } 
            return true;
        }
    }
}
