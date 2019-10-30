using System.Security.Claims;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Domain.Contracts;
using SignalRHub = Microsoft.AspNetCore.SignalR.Hub;

namespace WeatherAttack.Hub.Hubs
{
    public abstract class HubBase : SignalRHub, IHub
    {
        private IUserRepository UserRepository { get; }

        private long GetUserId()
        {
            return int.Parse(
                Context.User
                    .FindFirst(claim =>
                        claim.Type == ClaimTypes.PrimarySid)
                    .Value);
        }

        public async virtual Task<UserResponseDto> GetUser()
        {
            return await UserRepository.FindAsync(GetUserId(), 
                u => new UserResponseDto 
                { 
                    Id = u.Id, 
                    Username = u.Username,
                    Character = new CharacterDto 
                    {  
                        Id = u.Character.Id,
                        Battles = u.Character.Battles,
                        HealthPoints = u.Character.HealthPoints,
                        ManaPoints = u.Character.ManaPoints,
                        Wins = u.Character.Wins,
                        Losses = u.Character.Losses,
                        Medals = u.Character.Medals,
                        UserId = u.Id,
                    } 
                });
        }

        protected HubBase(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
    }
}
