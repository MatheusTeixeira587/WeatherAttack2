using System.Threading.Tasks;
using WeatherAttack.Contracts.Dtos.User.Response;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IHub
    {
        Task<UserResponseDto> GetUser();
    }
}