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
    public class AboutsController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutsController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        // GET: api/<AboutsController>
        [HttpGet]
        public IActionResult GetAbouts()
        {
            return Ok(_aboutRepository.GetAllAbouts());
        }

        // GET api/<AboutsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var about = _aboutRepository.GetAboutById(id);
            if (about == null)
            {
                return NotFound();
            }
            return Ok(about);
        }

        // POST api/<AboutsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AboutsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AboutsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
