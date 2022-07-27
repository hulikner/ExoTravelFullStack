using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ExoTravelFullStack.Models;
using ExoTravelFullStack.Repositories;
using System.Security.Claims;


namespace ExoTravelFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogsController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public LogsController(ILogRepository logRepository, IUserProfileRepository userProfileRepository)
        {
            _logRepository = logRepository;
            _userProfileRepository = userProfileRepository;
        }

        // GET: api/<LogsController>
        [HttpGet]
        public IActionResult GetLogs()
        {
            return Ok(_logRepository.GetAllLogs());
        }

        [HttpGet("GetLogsByUserProfileId")]
        public IActionResult GetLogsByUserProfileId()
        {
            var user = GetCurrentUserProfile();
            var log = _logRepository.GetLogsByUserProfileId(user.Id);
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
            var user = GetCurrentUserProfile();
            log.UserProfileId = user.Id;
            _logRepository.Add(log);
            return CreatedAtAction("Get", new { id = log.Id }, log);
        }

        // PUT api/<LogsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Log log)
        {
            var user = GetCurrentUserProfile();
            log.UserProfileId = user.Id;

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

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
