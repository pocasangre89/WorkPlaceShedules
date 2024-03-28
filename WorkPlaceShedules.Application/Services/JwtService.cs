using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Services.Interfaces;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;

namespace WorkPlaceShedules.Application.Services
{
    public class JwtService: IJWTService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IConfiguration _configuration;

        public JwtService(IUsersRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public string GenerateToken(string email)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string key = _configuration["Jwt:Key"];
            string issuer = _configuration["Jwt:Issuer"];
            string audiencia = _configuration["Jwt:Audience"];

            UsersEntity user = _userRepository.GetByEmail(email);

            var tokenKey = Encoding.UTF8.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", user.UserId.ToString()),
                }),
                Expires = System.DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256),
                Issuer = issuer,
                Audience = audiencia
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenResponse = tokenHandler.WriteToken(token);

            return tokenResponse;

        }
    }
}
