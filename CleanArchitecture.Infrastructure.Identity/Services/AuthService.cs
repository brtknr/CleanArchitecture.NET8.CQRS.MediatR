using CleanArchitecture.Application.Common.Services.Identity;
using CleanArchitecture.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity.Services
{
    public class AuthService : IAuthService
    {
        readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int minute,bool isBusiness)
        {
            Token token = new();
            
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);

            // claims role definitions

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires:token.Expiration,
                notBefore:DateTime.UtcNow,
                signingCredentials:signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
