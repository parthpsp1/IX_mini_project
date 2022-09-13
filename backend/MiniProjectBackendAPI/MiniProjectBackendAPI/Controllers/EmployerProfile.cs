using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniProjectBackendAPI.Authentication;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.Controllers
{
    [Authorize(Roles = "Executive")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerProfile : ControllerBase
    {
        private readonly UserManager<AuthenticateUser> _userManager;
        public EmployerProfile(UserManager<AuthenticateUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<Object> GetEmployerProfile(int id)
        {
            string EmployerId = User.Claims.First(id => id.Type == "UserId").Value;
            var employerProfile = await _userManager.FindByIdAsync(EmployerId);
            return new
            {
                employerProfile.UserName,
            };
        }

    }
}
