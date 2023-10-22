
using API_IBGE.Entities.Dtos;

namespace API_IBGE.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> UserLoginAsync(UserLoginDto userLoginDto);
        Task<bool> RegisterUserAsync(UserRegisterDto userRegister);
    }
}
