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
    public class ReceiptsController : ControllerBase
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptsController(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        // GET: api/<ReceiptsController>
        [HttpGet]
        public IActionResult GetReceipts()
        {
            return Ok(_receiptRepository.GetAllReceipts());
        }

        [HttpGet("GetAllReceiptsByUserId/{id}")]
        public IActionResult GetAllReceiptsByUserId(int id)
        {
            return Ok(_receiptRepository.GetAllReceiptsByUserId(id));
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
    }
}
