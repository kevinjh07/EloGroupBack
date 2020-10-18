using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EloGroupBack.Configuration;
using EloGroupBack.Exceptions;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EloGroupBack.Services
{
    public class AuthService : IAuthService
    {
        private readonly IOptions<AppSettings> _appSettings;

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(IOptions<AppSettings> appSettings,
            UserManager<ApplicationUser> userManager)
        {
            _appSettings = appSettings;
            _userManager = userManager;
        }

        public async Task<string> LoginAsync(LoginDto login)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == login.UserName);

            if (user == null)
            {
                throw new UnprocessableEntityException("Usuário não encontrado!");
            }

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
            {
                throw new UnprocessableEntityException("Usuário ou senha inválidos!");
            }

            return GetToken(user);
        }

        private string GetToken(ApplicationUser user)
        {
            var tokenDescriptor = GetSecurityTokenDescriptor(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor(ApplicationUser user)
        {
            var chars = _appSettings.Value.Secret;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chars));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }
    }
}