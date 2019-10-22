using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Security.Commands;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using System;
using System.Text;
using WeatherAttack.Security.Entities;
using WeatherAttack.Contracts.interfaces;
using WeatherAttack.Domain.Notifications;
using System.Threading.Tasks;

namespace WeatherAttack.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public IUserRepository Context { get; }

        public SecuritySettings Options { get; }

        public IPasswordService PasswordService { get; }

        public AuthenticationService(IUserRepository context, SecuritySettings options, IPasswordService passwordService)
        {
            Context = context;
            Options = options;
            PasswordService = passwordService;
        }

        public async Task<LoginCommand> GrantAuthorizationAsync(LoginCommand command)
        {
            var result = await Context
                .FindAsync(u => u.Username == command.Username);

            if (result != null && PasswordService.CheckPassword(command.Password, result.Password))
            {
                command.Token = new JwtSecurityTokenHandler().WriteToken(
                    CreateToken(result.Id, result.Username, result.PermissionLevel)
                );
            }
            else
            {
                command.AddNotification(WeatherAttackNotifications.Command.InvalidCredentials);
            }

            return command;
        }

        private JwtSecurityToken CreateToken(long id, string username, byte userPermissionLevel)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.SigningKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var permissionLevel = userPermissionLevel == 1 ? "Admin" : "User";
            return new JwtSecurityToken
            (
                claims: new[]
                {
                    new Claim(ClaimTypes.PrimarySid, id.ToString()),
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, permissionLevel)
                },
                expires: DateTime.Now.AddMinutes(Options.TokenExpirationTime),
                signingCredentials: signingCredentials
            );
        }
    }
}
