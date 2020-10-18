using System.Threading.Tasks;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto login);
    }
}