using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniProjectBackendAPI.Authentication;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<AuthenticateUser> _userManager;
        public UserProfileController(UserManager<AuthenticateUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<Object> GetUserProfile()
        {
            string UserId = User.Claims.First(id => id.Type == "UserID").Value;
            var UserProfile = await _userManager.FindByIdAsync(UserId);
            return new
            {
                UserProfile.UserName,
                UserProfile.FirstName,
                UserProfile.LastName,
                UserProfile.Email,
                UserProfile.PhoneNumber,
                UserProfile.AlternatePhoneNumber,
                UserProfile.TenthPercentage,
                UserProfile.TwelthPercentage,
                UserProfile.BachlorsPercentage,
                UserProfile.DiplomaPercentage,
                UserProfile.MastersPercentage,
                UserProfile.DoctoratePhDPercentage,
                UserProfile.Certification
            };
        }
    }
}
