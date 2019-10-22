using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Interfaces;

namespace WeatherAttack.Security.Commands.Handlers
{
    public class LoginActionHandler : IActionHandlerAsync<LoginCommand>
    {
        private IAuthenticationService AuthenticationService { get; }

        public LoginActionHandler(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        public async System.Threading.Tasks.Task<LoginCommand> ExecuteActionAsync(LoginCommand command)
        {
            return (await AuthenticationService.GrantAuthorizationAsync(command)) as LoginCommand;
        }
    }
}
