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
        public IActionResult Job(int id)
        {
            return Ok(_jobService.Job(id));
        }

        [HttpPost]
        public IActionResult Job(Jobs job)
        {
            return Ok(_jobService.Job(job));
        }

        [HttpPut]
        public IActionResult UpdateJob(Jobs job)
        {
            return Ok(_jobService.UpdateJob(job));
        }

        [HttpDelete]
        public IActionResult RemoveJob(int id)
        {
            return Ok(_jobService.Remove(id));
        }
    }
}
