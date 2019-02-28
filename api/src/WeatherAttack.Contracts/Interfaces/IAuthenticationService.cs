using WeatherAttack.Contracts.Command;

namespace WeatherAttack.Contracts.Interfaces
{
    public interface IAuthenticationService
    {
        CommandBase GrantAuthorization(CommandBase command);
    }
}
