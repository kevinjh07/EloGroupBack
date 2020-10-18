using System;
using System.Linq;
using System.Threading.Tasks;
using EloGroupBack.Exceptions;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace EloGroupBack.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IAuthService _authService;

        public UserService(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<string> SaveUser(LoginDto loginDto)
        {
            ValidateSameUsername(loginDto.UserName);

            var user = new ApplicationUser {UserName = loginDto.UserName};

            var result = await _userManager.CreateAsync(user, loginDto.Password);

            if (!result.Succeeded)
            {
                throw new UnprocessableEntityException("Não foi possível cadastrar o usuário, tente novamente");
            }

            return await _authService.LoginAsync(loginDto);
        }

        private void ValidateSameUsername(string userName)
        {
            if (_userManager.Users.Any(u => string.Compare(userName, u.UserName,
                StringComparison.CurrentCultureIgnoreCase) == 0))
            {
                throw new UnprocessableEntityException("Já existe um usuário cadastrado com este nome");
            }
        }
    }
}