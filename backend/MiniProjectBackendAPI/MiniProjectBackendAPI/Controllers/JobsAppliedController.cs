using Microsoft.AspNetCore.Mvc;
using MiniProjectBackendAPI.Service;

namespace MiniProjectBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsAppliedController : ControllerBase
    {
        private readonly IJobsAppliedService _jobsAppliedService;

        public JobsAppliedController(IJobsAppliedService jobsAppliedService)
        {
            _jobsAppliedService = jobsAppliedService;
        }

        [HttpGet]
        public IActionResult JobsApplied()
        {
            return Ok(_jobsAppliedService.JobsApplied());
        }

    }
}
