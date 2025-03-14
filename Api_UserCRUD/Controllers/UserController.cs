using Azure.Core;
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
            Response response = _userValidation.Create_User(request);

            if (response.IdError == 0) return Ok(response);
            else if (response.IdError == -999) return StatusCode(500, response);
            else return BadRequest(response);
        }

        [HttpGet("[action]/{id?}")]
        public IActionResult ReadUser(string? id = null)
        {
            Response response = new();

            if (string.IsNullOrEmpty(id))
                response = _userValidation.Read_Users();
            else
                response = _userValidation.Read_User(id);


            if (response.IdError == 0) 
                return Ok(response);
            else if (response.IdError == -999) 
                return StatusCode(500, response);
            else 
                return BadRequest(response);
        }

        [HttpPut("[action]")]
        public IActionResult UpdateUser(UpdateUserRequest request)
        {
            Response response = _userValidation.Update_User(request);

            if (response.IdError == 0)
                return Ok(response);
            else if (response.IdError == -999)
                return StatusCode(500, response);
            else
                return BadRequest(response);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteUser(string id)
        {
            Response response = _userValidation.Delete_User(id);

            if (response.IdError == 0)
                return Ok(response);
            else if (response.IdError == -999)
                return StatusCode(500, response);
            else
                return BadRequest(response);
        }

        [HttpPost("[action]")]
        public IActionResult Login(LoginRequest request)
        {
            Response response = _loginValidation.User_Login(request);

            if (response.IdError == 0)
                return Ok(response);
            else if (response.IdError == -999)
                return StatusCode(500, response);
            else
                return BadRequest(response);
        }
    }
}
