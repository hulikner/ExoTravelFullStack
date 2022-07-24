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
    public class LogsController : ControllerBase
    {
        private readonly ILogRepository _logRepository;

        public LogsController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        // GET: api/<LogsController>
        [HttpGet]
        public IActionResult GetLogs()
        {
            return Ok(_logRepository.GetAllLogs());
        }

        [HttpGet("GetLogsByUserProfileId/{id}")]
        public IActionResult GetLogsByUserProfileId(int id)
        {
            var log = _logRepository.GetLogsByUserProfileId(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        // GET api/<LogsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var log = _logRepository.GetLogById(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        // POST api/<LogsController>
        [HttpPost]
        public IActionResult Post(Log log)
        {
            _logRepository.Add(log);
            return CreatedAtAction("Get", new { id = log.Id }, log);
        }

        // PUT api/<LogsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Log log)
        {
            if (id != log.Id)
            {
                return BadRequest();
            }

            _logRepository.Update(log);
            return NoContent();

        }

        // DELETE api/<LogsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logRepository.Delete(id);
            return NoContent();
        }
    }
}
