using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniProjectBackendAPI.Model;
using MiniProjectBackendAPI.Service;
using System.Linq;

namespace MiniProjectBackendAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //public IActionResult Users()
        //{
        //    return Ok(_userService.Users());
        //}

        [HttpGet]
        public IActionResult Users()
        {
            string UserId = User.Claims.First(o => o.Type == "UserId").Value;
            return Ok(_userService.Users(UserId));
        }

        [HttpPost]
        public IActionResult Users(Users usersModel)
        {
            return Ok(_userService.Users(usersModel));
        }

        [HttpPut]
        public IActionResult Users(Users usersModel, string id)
        {
            return Ok(_userService.Users(usersModel, id));
        }

        [HttpDelete]
        public IActionResult RemoveUser(string id)
        {
            return Ok(_userService.Remove(id));
        }
    }
}
