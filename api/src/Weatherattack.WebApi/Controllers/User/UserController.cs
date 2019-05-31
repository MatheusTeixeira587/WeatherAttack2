using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;
using WeatherAttack.WebApi.Extensions.Controller;

namespace Weatherattack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : ControllerBase
    {
        private IActionHandler<GetAllUsersCommand> GetAllUserHandler { get; }
        private IActionHandler<AddUserCommand> AddUserHandler { get; }
        private IActionHandler<GetUserCommand> GetUserHandler { get; }
        private IActionHandler<DeleteUserCommand> DeleteUserHandler { get; }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]GetAllUsersCommand command)
        {
            return await Task.Run(() =>
            {
                return this.Response(GetAllUserHandler.ExecuteAction(command));
            });
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> Get([FromRoute]GetUserCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.Id = id;
                return this.Response(GetUserHandler.ExecuteAction(command));
            });
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Add([FromBody]AddUserCommand command)
        {
            return await Task.Run(() =>
            {
                command.User.Id = 0;
                return this.Response(AddUserHandler.ExecuteAction(command));
            });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AddUserCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.User.Id = id;
                return this.Response(AddUserHandler.ExecuteAction(command));
            });
        }

        [HttpDelete("{Id:min(1)}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.Id = id;
                return this.Response(DeleteUserHandler.ExecuteAction(command));
            });
        }

        public UserController(
            IActionHandler<GetAllUsersCommand> getAllUsersActionHandler,
            IActionHandler<AddUserCommand> addUserActionHandler,
            IActionHandler<GetUserCommand> getUserActionHandler,
            IActionHandler<DeleteUserCommand> deleteUserActionHandler
        )
        {
            GetAllUserHandler = getAllUsersActionHandler;
            AddUserHandler = addUserActionHandler;
            GetUserHandler = getUserActionHandler;
            DeleteUserHandler = deleteUserActionHandler;
        }
    }
}
