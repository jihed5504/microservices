using Conan_1.Helpers;
using Conan_1.Models.Requests;
using Conan_1.Models.Requests.Queries;
using Conan_1.Models.Responses;
using Conan_1.Services.V1;
using Microsoft.AspNetCore.Mvc;

namespace Conan_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserResponse> createUser([FromForm] CreateUserRequest createUserRequest)
        {
            var user = _userService.createUser(createUserRequest);
            return Ok(user);
        }

        //[Authorize]
        [HttpGet]
        public ActionResult<PagedResponse<UserResponse>> GetAll([FromQuery] UsersParameters userParameters)
        {
            var user = _userService.GetAll(userParameters);

            return Ok(user);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var users = _userService.GetById(id.ToString());
            return Ok(users);
        }
        [HttpPut("{id:Guid}")]
        public ActionResult<IEnumerable<UserResponse>> UpdateUser(Guid id,[FromForm] UpdateUserRequest updateUserRequest)
        {
            var user = _userService.UpdateUser(id.ToString(), updateUserRequest);
            return Ok(user);
        }
        [HttpDelete("{id:Guid}")]
        public ActionResult<IEnumerable<UserResponse>> DeleteUser(Guid id)
        {
            _userService.DeleteUser(id.ToString());
            return NoContent();
        }
    }
}
