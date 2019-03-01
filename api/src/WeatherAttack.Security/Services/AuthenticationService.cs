using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Security.Commands;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using System;
using System.Text;
using Microsoft.Extensions.Options;
using WeatherAttack.Security.Entities;
using WeatherAttack.Contracts.interfaces;
using WeatherAttack.Domain.Notifications;
using Microsoft.AspNetCore.Identity;

namespace WeatherAttack.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public IUserRepository Context { get; }

        public IOptions<SecuritySettings> Options { get; }

        public IPasswordService PasswordService { get; }

        public AuthenticationService(IUserRepository context, IOptions<SecuritySettings> options, IPasswordService passwordService)
        {
            Context = context;
            Options = options;
            PasswordService = passwordService;
        }

        public CommandBase GrantAuthorization(CommandBase command)
        {
            var loginCommand = command as LoginCommand;

            var result = Context.FindBy(u =>
            u.Username == loginCommand.Username,
            s => new User(s.Id, s.Username, s.PermissionLevel, s.Password)).FirstOrDefault();

            if (result != null && PasswordService.CheckPassword(loginCommand.Password, result.Password))
            {
                loginCommand.Token = new JwtSecurityTokenHandler().WriteToken(
                    CreateToken(result.Id, result.Username, result.PermissionLevel)
                );
            }
            else
            {
                loginCommand.AddNotification(WeatherAttackNotifications.Command.InvalidCredentials);
            }

            return loginCommand;
        }

        private JwtSecurityToken CreateToken(long id, string username, byte userPermissionLevel)
        {
            var claimIdentity = new IdentityOptions();

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.Value.SigningKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var permissionLevel = userPermissionLevel == 1 ? "Admin" : "User";
            return new JwtSecurityToken
            (
                claims: new[]
                {
                    new Claim(claimIdentity.ClaimsIdentity.UserIdClaimType, id.ToString()),
                    new Claim(claimIdentity.ClaimsIdentity.UserNameClaimType, username),
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, permissionLevel)
                },
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signingCredentials
            );
        }
    }
}
