using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniProjectBackendAPI.Model;
using MiniProjectBackendAPI.Service;

namespace MiniProjectBackendAPI.Controllers
{
    [Authorize(Roles = "Executive")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public IActionResult Employers()
        {
            return Ok(_employerService.Employers());
        }

        [HttpGet("{id}")]
        public IActionResult Employers(string id)
        {
            return Ok(_employerService.Employer(id));
        }

        [HttpPost]
        public IActionResult Employer(Employer employerModel)
        {
            return Ok(_employerService.Employer(employerModel));
        }

        [HttpPut]
        public IActionResult Employers(Employer employerModel)
        {
            return Ok(_employerService.Employer(employerModel));
        }

        [HttpDelete]
        public IActionResult RemoveUser(string id)
        {
            return Ok(_employerService.Remove(id));
        }
    }
}
