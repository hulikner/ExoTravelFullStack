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
    public class ExoPlanetsController : ControllerBase
    {
        private readonly IExoPlanetRepository _exoPlanetRepository;

        public ExoPlanetsController(IExoPlanetRepository exoPlanetRepository)
        {
            _exoPlanetRepository = exoPlanetRepository;
        }

        // GET: api/<ExoPlanetsController>
        [HttpGet]
        public IActionResult GetExoPlanets()
        {
            return Ok(_exoPlanetRepository.GetAllExoPlanets());
        }

        [HttpGet("GetAllExoPlanetsByLightYearAsc")]
        public IActionResult GetAllExoPlanetsByLightYearAsc()
        {
            return Ok(_exoPlanetRepository.GetAllExoPlanetsByLightYearAsc());
        }

        [HttpGet("GetAllExoPlanetsByLightYearDesc")]
        public IActionResult GetAllExoPlanetsByLightYearDesc()
        {
            return Ok(_exoPlanetRepository.GetAllExoPlanetsByLightYearDesc());
        }

        [HttpGet("GetAllExoPlanetsByRatingAsc")]
        public IActionResult GetAllExoPlanetsByRatingAsc()
        {
            return Ok(_exoPlanetRepository.GetAllExoPlanetsByRatingAsc());
        }

        [HttpGet("GetAllExoPlanetsByRatingDesc")]
        public IActionResult GetAllExoPlanetsByRatingDesc()
        {
            return Ok(_exoPlanetRepository.GetAllExoPlanetsByRatingDesc());
        }

        // GET api/<ExoPlanetsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var exoPlanet = _exoPlanetRepository.GetExoPlanetById(id);
            if (exoPlanet == null)
            {
                return NotFound();
            }
            return Ok(exoPlanet);
        }

        // POST api/<ExoPlanetsController>
        [HttpPost]
        public IActionResult Post(ExoPlanet exoPlanet)
        {
            _exoPlanetRepository.Add(exoPlanet);
            return CreatedAtAction("Get", new { id = exoPlanet.Id }, exoPlanet);
        }

        // PUT api/<ExoPlanetsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ExoPlanet exoPlanet)
        {
            if (exoPlanet.Id != exoPlanet.Id)
            {
                return BadRequest();
            }

            _exoPlanetRepository.Update(exoPlanet);
            return NoContent();

        }

        // DELETE api/<ExoPlanetsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _exoPlanetRepository.Delete(id);
            return NoContent();
        }
    }
}
