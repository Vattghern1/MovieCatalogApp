﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieCatalog.API.Models
{
    public class JwtConfigurations
    {
        public const string Issuer = "JwtTestIssuer"; // издатель токена
        public const string Audience = "JwtTestClient"; // потребитель токена
        private const string Key = "SuperSecretKeyBazingaLolKek!*228322";   // ключ для шифрации
        public const int Lifetime = 1440; // время жизни токена - 1400 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }

    }
}
