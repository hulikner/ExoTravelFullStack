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
    public class ReceiptsController : ControllerBase
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IUserProfileRepository _userProfileRepository;


        public ReceiptsController(IReceiptRepository receiptRepository, IUserProfileRepository userProfileRepository)
        {
            _receiptRepository = receiptRepository;
            _userProfileRepository = userProfileRepository;
        }

        // GET: api/<ReceiptsController>
        [HttpGet]
        public IActionResult GetReceipts()
        {
            return Ok(_receiptRepository.GetAllReceipts());
        }

        [HttpGet("GetAllReceiptsByUserId")]
        public IActionResult GetAllReceiptsByUserId(int id)
        {
            var user = GetCurrentUserProfile();
            return Ok(_receiptRepository.GetAllReceiptsByUserId(user.Id));
        }

        // GET api/<ReceiptsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var receipt = _receiptRepository.GetReceiptById(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return Ok(receipt);
        }

        [HttpGet("GetReceiptByLogId/{id}")]
        public IActionResult GetReceiptByLogId(int id)
        {
            var receipt = _receiptRepository.GetReceiptByLogId(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return Ok(receipt);
        }

        // POST api/<ReceiptsController>
        [HttpPost]
        public IActionResult Post(Receipt receipt)
        {
            _receiptRepository.Add(receipt);
            return CreatedAtAction("Get", new { id = receipt.Id }, receipt);
        }

        // PUT api/<ReceiptsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceiptsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
