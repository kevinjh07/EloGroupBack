using System;
using System.Linq;
using System.Threading.Tasks;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace EloGroupBack.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto> SaveUser(LoginDto loginDto)
        {
            if (_userManager.Users.Any(u => string.Compare(loginDto.UserName, u.UserName,
                StringComparison.CurrentCultureIgnoreCase) == 0))
            {
                return new ResponseDto(nameof(SaveUser), ResultadoResponse.Erro,
                    new {message = "Já existe um usuário cadastrado com nome"});
            }

            var user = new ApplicationUser {UserName = loginDto.UserName};

            var result = await _userManager.CreateAsync(user, loginDto.Password);

            if (!result.Succeeded)
            {
                return new ResponseDto(nameof(SaveUser), ResultadoResponse.Erro,
                    new {message = "Não foi possível cadastrar o usuário, tente novamente"});
            }

            user.PasswordHash = string.Empty;
            return new ResponseDto(nameof(SaveUser), ResultadoResponse.Sucesso, null);
        }
    }
}