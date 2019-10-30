using System.Threading.Tasks;
using WeatherAttack.Security.Commands;

public interface IAuthenticationService
{
    Task<LoginCommand> GrantAuthorizationAsync(LoginCommand command);
}