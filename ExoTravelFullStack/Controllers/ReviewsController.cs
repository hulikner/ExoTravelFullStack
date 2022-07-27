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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult GetReviews()
        {
            return Ok(_reviewRepository.GetAllReviews());
        }

        [HttpGet("GetAllReviewsByExoPlanet/{id}")]
        public IActionResult GetAllReviewsByExoPlanet(int id)
        {
            return Ok(_reviewRepository.GetAllReviewsByExoPlanet(id));
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _reviewRepository.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post(Review review)
        {
            _reviewRepository.Add(review);
            return CreatedAtAction("Get", new { id = review.Id }, review);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Review review)
        {
            //if (id != review.Id)
            //{
            //    return BadRequest();
            //}

            _reviewRepository.Update(review);
            return NoContent();

        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reviewRepository.Delete(id);
            return NoContent();
        }
    }
}
