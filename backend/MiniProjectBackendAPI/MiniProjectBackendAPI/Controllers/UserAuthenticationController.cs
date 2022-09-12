using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.Model;
using MiniProjectBackendAPI.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MiniProjectBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly UserManager<AuthenticateUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmployerService _employerService;

        public UserAuthenticationController(UserManager<AuthenticateUser> userManager,RoleManager<IdentityRole> roleManager ,IConfiguration configuration, IEmployerService employerService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            _configuration = configuration;
            _employerService = employerService;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            AuthenticateUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                AlternatePhoneNumber = model.AlternatePhoneNumber,
                TenthPercentage = model.TenthPercentage,
                TwelthPercentage = model.TwelthPercentage,
                DiplomaPercentage= model.TwelthPercentage,
                BachlorsPercentage = model.BachlorsPercentage,
                MastersPercentage = model.MastersPercentage,
                DoctoratePhDPercentage = model.DoctoratePhDPercentage,
                Certification = model.Certification
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("registerEmployer")]
        public async Task<IActionResult> RegisterEmployer(EmployerRegistration model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            AuthenticateUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };


            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //if (!await _roleManager.RoleExistsAsync(UserRoles.employerExecutive))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.employerExecutive));
            //if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //{
            //    await _userManager.AddToRoleAsync(user, UserRoles.employerExecutive);
            //    //await _employerService.Employer();
            //    return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
            //}

            await _roleManager.CreateAsync(new IdentityRole(UserRoles.employerExecutive));
            await _userManager.AddToRoleAsync(user, UserRoles.employerExecutive);

            Employer employerModel = new()
            {
                Username = user.UserName,
                EmployerId = user.Id,
                CompanyName = model.CompanyName,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                AlternatePhoneNumber = model.AlternatePhoneNumber,
                Category = model.Category,
                Details = model.Details
            };
            await _employerService.Employer(employerModel);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            //return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [Route("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin(AdminRegistration model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            AuthenticateUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.employerExecutive))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("loginUser")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserID", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("loginAdmin")]
        public async Task<IActionResult> LoginAdmin(AdminLogin model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("loginEmployer")]
        public async Task<IActionResult> LoginEmployer(EmployerLogin model)
        {
            var employer = await _userManager.FindByNameAsync(model.Username);
            if (employer != null && await _userManager.CheckPasswordAsync(employer, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(employer);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, employer.UserName),
                    new Claim("UserID", employer.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    employerData = new
                    {
                        id= employer.Id,
                        companyname = employer.UserName,
                        
                    }
                });
            }
            return Unauthorized();
        }
    }
}
