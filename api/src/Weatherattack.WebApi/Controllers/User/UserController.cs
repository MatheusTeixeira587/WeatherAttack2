using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;

namespace Weatherattack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IActionHandler<GetAllUsersCommand> GetAllUserHandler { get; }
        private IActionHandler<AddUserCommand> AddUserHandler { get; }
        private IActionHandler<GetUserCommand> GetUserHandler { get; }
        private IActionHandler<DeleteUserCommand> DeleteUserHandler { get; }

        [Authorize, HttpGet]
        public async Task<GetAllUsersCommand> Get([FromRoute]GetAllUsersCommand command)
        {
            return await Task.Run(() =>
            {
                return GetAllUserHandler.ExecuteAction(command);
            });
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<GetUserCommand> Get([FromRoute]GetUserCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.Id = id;

                return GetUserHandler.ExecuteAction(command);
            });
        }

        [HttpPut]
        public async Task<AddUserCommand> AddOrEdit([FromBody]AddUserCommand command)
        {
            return await Task.Run(() =>
            {
                return AddUserHandler.ExecuteAction(command);
            });
        }

        [HttpDelete("{Id:min(1)}")]
        public async Task<DeleteUserCommand> Delete([FromRoute] DeleteUserCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.Id = id;

                return DeleteUserHandler.ExecuteAction(command);
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
