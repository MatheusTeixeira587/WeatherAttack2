using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;


namespace WeatherAttack.Application.Command.User.Handlers
{
    public sealed class GetPagedUsersActionHandler : IActionHandlerAsync<GetPagedUsersCommand>
    {
        private IUserRepository Context { get; }

        public GetPagedUsersActionHandler(IUserRepository context)
        {
            Context = context;
        }

        public async Task<GetPagedUsersCommand> ExecuteActionAsync(GetPagedUsersCommand command)
        {
            int skip = (int) (command.PageSize * (command.PageNumber - 1));
            int take = (int) command.PageSize;

            var result = await Context.GetAsync(skip, take, u => new UserResponseDto()
            {
                Id = u.Id,
                Email = u.Email,
                Username = u.Username,
                PermissionLevel = u.PermissionLevel,
                Character = new CharacterDto()
                {
                    Id = u.Character.Id,
                    Losses = u.Character.Losses,
                    Battles = u.Character.Battles,
                    Wins = u.Character.Wins,
                    UserId = u.Id,
                    Medals = u.Character.Medals,
                    HealthPoints = u.Character.HealthPoints,
                    ManaPoints = u.Character.ManaPoints
                }
            });

            if (result is null)
                return command;

            command.PageNumber = (skip + take) / command.PageSize;
            command.Result = result;

            long totalRecords = await Context.CountAsync();

            command.PageCount = 
                (totalRecords / command.PageSize) < 1 
                    ? 1
                    : totalRecords / command.PageSize;

            command.TotalRecords = totalRecords;

            return command;
        }
    }
}
