using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Application.Contracts.Command;

namespace Weatherattack.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IActionHandler<GetAllUsersCommand> GetAllUserHandler { get; }
        private IActionHandler<AddUserCommand> AddUserHandler { get; }
        private IActionHandler<GetUserCommand> GetUserHandler { get; }

        [Route("list")]
        [HttpGet]
        public GetAllUsersCommand Get([FromRoute]GetAllUsersCommand command)
        {   
            return GetAllUserHandler.ExecuteAction(command);
        }

        [HttpGet("{Id:min(1)}")]
        public GetUserCommand Get([FromRoute]GetUserCommand command)
        {
            return GetUserHandler.ExecuteAction(command);
        }

        [HttpPost]
        public AddUserCommand AddOrEdit([FromBody]AddUserCommand command)
        {
            return AddUserHandler.ExecuteAction(command);
        }

        [HttpGet("{id:min(1)}/drop")]
        public DateTime? Delete([FromRoute] long id)
        {
            DateTime? data = null;
            List<DateTime?> dataList = null;
            data = dataList.FirstOrDefault();
            return data;
        }

        public UserController(
            IActionHandler<GetAllUsersCommand> getAllUsersActionHandler,
            IActionHandler<AddUserCommand> addUserActionHandler,
            IActionHandler<GetUserCommand> getUserActionHandler
            )
        {
            GetAllUserHandler = getAllUsersActionHandler;
            AddUserHandler = addUserActionHandler;
            GetUserHandler = getUserActionHandler;
        }
    }
}
