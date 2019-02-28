using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Interfaces;

namespace WeatherAttack.Security.Commands.Handlers
{
    public class LoginActionHandler : IActionHandler<LoginCommand>
    {
        private IAuthenticationService AuthenticationService { get; }

        public LoginActionHandler(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        public LoginCommand ExecuteAction(LoginCommand command)
        {
            return AuthenticationService.GrantAuthorization(command) as LoginCommand;
        }
    }
}
