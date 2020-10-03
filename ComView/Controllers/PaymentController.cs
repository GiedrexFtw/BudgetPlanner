using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComView.Data;
using ComView.Dto;
using ComView.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComView.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo _repository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepo paymentRepo, IMapper mapper)
        {
            _repository = paymentRepo;
            _mapper = mapper;

        }
        // GET: api/<PaymentController>
        [HttpGet]
        public ActionResult<IEnumerable<Payment>> Get()
        {
            var payments = _repository.GetPaymentList();

            return Ok(_mapper.Map<IEnumerable<PaymentReadDto>>(payments));
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<PaymentReadDto> Get(int id)
        {
            var payment = _repository.GetPaymentById(id);
            if (payment != null)
            {
                return Ok(_mapper.Map<PaymentReadDto>(payment));
            }
            else
                return NotFound();
           
        }

        // POST api/<PaymentController>
        [HttpPost]
        public ActionResult<PaymentReadDto> Post([FromBody]PaymentCreateDto createDto)
        {
            var payment = _mapper.Map<Payment>(createDto);
            _repository.CreatePayment(payment);
            _repository.SaveChanges();
            var readDto = _mapper.Map<PaymentReadDto>(payment);
            return CreatedAtRoute(nameof(Get), new {Id = readDto.Id }, readDto);
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
