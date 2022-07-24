using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Repositories;

namespace ExoTravelFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubDrivesController : ControllerBase
    {
        private readonly IHubDriveRepository _hubDriveRepository;

        public HubDrivesController(IHubDriveRepository hubDriveRepository)
        {
            _hubDriveRepository = hubDriveRepository;
        }

        // GET: api/<HubDrivesController>
        [HttpGet]
        public IActionResult GetHubDrives()
        {
            return Ok(_hubDriveRepository.GetAllHubDrives());
        }

        // GET api/<HubDrivesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hubDrive = _hubDriveRepository.GetHubDriveById(id);
            if (hubDrive == null)
            {
                return NotFound();
            }
            return Ok(hubDrive);
        }

        // POST api/<HubDrivesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HubDrivesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HubDrivesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
