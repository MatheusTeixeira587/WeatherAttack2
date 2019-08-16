using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using Entities = WeatherAttack.Domain.Entities;


namespace WeatherAttack.Application.Command.User.Handlers
{
    public class GetPagedUsersActionHandler : IActionHandler<GetPagedUsersCommand>
    {
        private IUserRepository Context { get; }

        private IMapper<Entities.User, UserRequestDto, UserResponseDto> Mapper { get; }

        public GetPagedUsersActionHandler(IUserRepository context, IMapper<Entities.User, UserRequestDto, UserResponseDto> mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public GetPagedUsersCommand ExecuteAction(GetPagedUsersCommand command)
        {
            int skip = (int)(command.PageSize * (command.PageNumber - 1));
            int take = (int)command.PageSize;

            var result = Context
                .Get(skip, take)
                ?.Select(r => Mapper.ToDto(r))
                .ToList();

            if (result is null)
                return command;

            long totalRecords = Context.Count();

            command.PageNumber = (skip + take) / command.PageSize;
            command.PageCount = 
                totalRecords / command.PageSize < 1 
                    ? 1
                    : totalRecords / command.PageSize;

            command.TotalRecords = totalRecords;

            command.Result = result;

            return command;
        }
    }
}
