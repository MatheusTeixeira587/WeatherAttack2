using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IAuthenticationService
    {
        Task<CommandBase> GrantAuthorizationAsync(CommandBase command);
    }
}
