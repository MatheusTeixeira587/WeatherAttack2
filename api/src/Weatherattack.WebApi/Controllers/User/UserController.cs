using Microsoft.AspNetCore.Mvc;
using WeatherAttack.Application.Command.User;

namespace Weatherattack.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values
        [Route("list")]
        [HttpGet]
        public GetAllUsersCommand Get([FromRoute]GetAllUsersCommand command)
        {
            command.Execute();
            return command;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut]
        public AddUserCommand Put([FromBody]AddUserCommand command)
        {
            command.Execute();
            return command;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
