using System.Threading.Tasks;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface IUserService
    {
        Task<ResponseDto> SaveUser(LoginDto userDto);
    }
}