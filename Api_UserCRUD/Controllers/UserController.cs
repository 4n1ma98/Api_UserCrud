using Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace Api_UserCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserValidation _userValidation;
        private readonly ILoginValidation _loginValidation;

        public UserController(IUserValidation userValidation, ILoginValidation loginValidation)
        {
            _userValidation = userValidation;
            _loginValidation = loginValidation;
        }

        [HttpPost("[action]")]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            _userValidation.Create_User(request);
            return Ok();
        }

        [HttpGet("[action]/{id?}")]
        public IActionResult ReadUser(string? id = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Ok(_userValidation.Read_Users());
            }
            else
            {
                return Ok(_userValidation.Read_User(id));
            }
        }

        [HttpPut("[action]")]
        public IActionResult UpdateUser(UpdateUserRequest request)
        {
            _userValidation.Update_User(request);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteUser(string id)
        {
            _userValidation.Delete_User(id);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(_loginValidation.User_Login(request));
        }
    }
}
