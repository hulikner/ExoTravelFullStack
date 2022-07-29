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
    [Authorize]
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

        [HttpGet("GetByLightYearAsc")]
        public IActionResult GetByLightYearAsc()
        {
            return Ok(_exoPlanetRepository.GetByLightYearAsc());
        }

        [HttpGet("GetByLightYearDesc")]
        public IActionResult GetByLightYearDesc()
        {
            return Ok(_exoPlanetRepository.GetByLightYearDesc());
        }

        [HttpGet("GetByRatingAsc")]
        public IActionResult GetByRatingAsc()
        {
            return Ok(_exoPlanetRepository.GetByRatingAsc());
        }

        [HttpGet("GetByRatingDesc")]
        public IActionResult GetByRatingDesc()
        {
            return Ok(_exoPlanetRepository.GetByRatingDesc());
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
            var planet = _exoPlanetRepository.GetExoPlanetById(exoPlanet.Id);
            planet.Rating = exoPlanet.Rating;
            //if (exoPlanet.Id != exoPlanet.Id)
            //{
            //    return BadRequest();
            //}

            _exoPlanetRepository.Update(planet);
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
