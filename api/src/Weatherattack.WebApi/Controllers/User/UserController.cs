using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Contracts.Command;

namespace WeatherAttack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : BaseController
    {
        private IActionHandler<AddUserCommand> AddUserHandler { get; }
        private IActionHandlerAsync<GetPagedUsersCommand> GetPagedUsersHandler { get; }
        private IActionHandlerAsync<GetUserCommand> GetUserHandler { get; }
        private IActionHandlerAsync<DeleteUserCommand> DeleteUserHandler { get; }

        [HttpGet("Page-{Page:min(1)}")]
        public async Task<IActionResult> Get([FromRoute]GetPagedUsersCommand command, long page)
        {
            return await Task.Run(async () =>
            {
                command.PageNumber = page;
                return GetResponse(await GetPagedUsersHandler.ExecuteActionAsync(command));
            });
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> Get([FromRoute]GetUserCommand command, long id)
        {
            return await Task.Run(async () =>
            {
                command.Id = id;
                return GetResponse(await GetUserHandler.ExecuteActionAsync(command));
            });
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Add([FromBody]AddUserCommand command)
        {
            return await Task.Run(() =>
            {
                command.User.Id = 0;
                return GetResponse(AddUserHandler.ExecuteAction(command));
            });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AddUserCommand command, long id)
        {
            return await Task.Run(() =>
            {
                command.User.Id = id;
                return GetResponse(AddUserHandler.ExecuteAction(command));
            });
        }

        [HttpDelete("{Id:min(1)}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand command, long id)
        {
            return await Task.Run(async () =>
            {
                command.Id = id;
                return GetResponse(await DeleteUserHandler.ExecuteActionAsync(command));
            });
        }

        public UserController(
            IActionHandler<AddUserCommand> addUserActionHandler,
            IActionHandlerAsync<GetUserCommand> getUserActionHandler,
            IActionHandlerAsync<DeleteUserCommand> deleteUserActionHandler,
            IActionHandlerAsync<GetPagedUsersCommand> getPagedUsersHandler
        )
        {
            AddUserHandler = addUserActionHandler;
            GetUserHandler = getUserActionHandler;
            DeleteUserHandler = deleteUserActionHandler;
            GetPagedUsersHandler = getPagedUsersHandler;
        }
    }
}
