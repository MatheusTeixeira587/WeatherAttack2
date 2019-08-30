﻿using System.Linq;
using System.Threading.Tasks;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Character;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Application.Command.Character.Handlers
{
    public class GetCharacterActionHandler : IActionHandler<GetCharacterCommand>
    {
        private ICharacterRepository Context { get; }

        private IMapper<Domain.Entities.Character, CharacterDto, CharacterDto> Mapper { get; }

        public GetCharacterActionHandler(ICharacterRepository context, IMapper<Domain.Entities.Character, CharacterDto, CharacterDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public GetCharacterCommand ExecuteAction(GetCharacterCommand command)
        {
            var result = Context
                .Find(c => c.UserId == command.Id)
                .SingleOrDefault();

            if (result is null)
                command.AddNotification(WeatherAttackNotifications.Character.InvalidCharacter);
            else 
                command.Result = Mapper.ToDto(result);

            return command;
        }
    }
}
