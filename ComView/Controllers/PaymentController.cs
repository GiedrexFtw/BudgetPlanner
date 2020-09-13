using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComView.Data;
using ComView.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComView.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MockPaymentRepo _repository = new MockPaymentRepo();
        // GET: api/<PaymentController>
        [HttpGet]
        public ActionResult<IEnumerable<Payment>> Get()
        {
            var payments = _repository.GetPaymentList();

            return Ok(payments);
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public ActionResult<Payment> Get(int id)
        {
            var payment = _repository.GetPaymentById(id);

            return Ok(payment);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
