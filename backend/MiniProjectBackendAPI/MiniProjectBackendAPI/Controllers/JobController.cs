using Microsoft.AspNetCore.Mvc;
using MiniProjectBackendAPI.Model;
using MiniProjectBackendAPI.Service;

namespace MiniProjectBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public IActionResult Jobs()
        {
            return Ok(_jobService.Jobs());
        }

        [HttpGet("{id}")]
        public IActionResult Jobs(int id)
        {
            return Ok(_jobService.Jobs(id));
        }

        [HttpPost]
        public IActionResult Jobs(Jobs jobsModel)
        {
            return Ok(_jobService.Jobs(jobsModel));
        }

        [HttpPut]
        public IActionResult Jobs(Jobs jobsModel , int id)
        {
            return Ok(_jobService.Jobs(jobsModel, id));
        }

        [HttpDelete]
        public IActionResult RemoveUser(int id)
        {
            return Ok(_jobService.Remove(id));
        }
    }
}
