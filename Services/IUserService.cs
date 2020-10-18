using System.Threading.Tasks;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface IUserService
    {
        Task<string> SaveUser(LoginDto userDto);
    }
}