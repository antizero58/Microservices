using K8sCrudTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace K8sCrudTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var res = await _userService.GetUsers();
            return res;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            try
            {
                var res = await _userService.GetUser(id);
                return Ok(res);
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost()]
        public async Task CreateUser(string firstName, string secondName)
        {
            await _userService.CreateUser(firstName, secondName);
        }

        [HttpPut]
        public async Task UpdateUser([FromBody]User user)
        {
            await _userService.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
        }
    }
}