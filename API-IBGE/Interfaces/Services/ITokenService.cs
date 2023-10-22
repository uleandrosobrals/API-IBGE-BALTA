using API_IBGE.Entities.Dtos;

namespace API_IBGE.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserLoginDto userLoginDto);
    }
}
