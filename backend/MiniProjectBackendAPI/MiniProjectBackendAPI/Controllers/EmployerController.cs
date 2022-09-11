﻿using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Employer(EmployerModel employeeModel)
        {
            return Ok(_employerService.Employer(employeeModel));
        }

        [HttpPut]
        public IActionResult Employers(EmployerModel employeeModel, string id)
        {
            return Ok(_employerService.Employer(employeeModel, id));
        }

        [HttpDelete]
        public IActionResult RemoveUser(string id)
        {
            return Ok(_employerService.Remove(id));
        }
    }
}
