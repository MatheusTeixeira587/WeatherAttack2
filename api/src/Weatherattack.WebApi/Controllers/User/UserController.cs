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
        private IActionHandlerAsync<AddUserCommand> AddUserHandler { get; }
        private IActionHandlerAsync<GetPagedUsersCommand> GetPagedUsersHandler { get; }
        private IActionHandlerAsync<GetUserCommand> GetUserHandler { get; }
        private IActionHandlerAsync<DeleteUserCommand> DeleteUserHandler { get; }

        [HttpGet("Page-{Page:min(1)}")]
        public async Task<IActionResult> GetAsync([FromRoute]GetPagedUsersCommand command, long page)
        {
            command.PageNumber = page;
            return GetResponse(await GetPagedUsersHandler.ExecuteActionAsync(command));
        }

        [HttpGet("{Id:min(1)}")]
        public async Task<IActionResult> GetAsync([FromRoute]GetUserCommand command, long id)
        {
            command.Id = id;
            return GetResponse(await GetUserHandler.ExecuteActionAsync(command));
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> AddAsync([FromBody]AddUserCommand command)
        {
            command.User.Id = 0;
            return GetResponse(await AddUserHandler.ExecuteActionAsync(command));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditAsync([FromBody] AddUserCommand command, long id)
        {
            command.User.Id = id;
            return GetResponse(await AddUserHandler.ExecuteActionAsync(command));
        }

        [HttpDelete("{Id:min(1)}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteUserCommand command, long id)
        {
            command.Id = id;
            return GetResponse(await DeleteUserHandler.ExecuteActionAsync(command));
        }

        public UserController(
            IActionHandlerAsync<AddUserCommand> addUserActionHandler,
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
