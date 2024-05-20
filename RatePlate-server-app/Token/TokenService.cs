using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RatePlate.Dto;
using RatePlate.Interface;
using RatePlate.Models;
using RatePlateserverapp.Userlogindto;
using RatePlateServerApp.User;

namespace RatePlate.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration config;
        public TokenServices(IConfiguration config){
            this.config = config;
        }

        public string GenerateToken(UserLoginDto login)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.id.ToString()),
                new Claim("username", login.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dd06a6ca-5f5e-4c4c-9b39-0448685f2103"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["JwtSettings:Issuer"],
                audience: config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}