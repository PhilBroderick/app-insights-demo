﻿using auth.Entities;
using auth.Helpers;
using auth.Interfaces;
using auth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEnumerable<User> _users = new List<User>
        {
            new User { Id = 1234, FirstName = "Phil", LastName = "Broderick", Username = "user1", Password = "Password1" },
            new User { Id = 4321, FirstName = "Phil", LastName = "Broderick", Username = "user2", Password = "Password2"}
        };

        private readonly AppSettings _appSettings;

        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public LoginResponse Login(LoginRequest model)
        {
            var user = _users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user is null) return null;

            var token = GenerateJwtToken(user);

            return new LoginResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
    }
}
