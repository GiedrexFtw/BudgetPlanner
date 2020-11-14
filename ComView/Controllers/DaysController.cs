using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComView.Data;
using ComView.Dto;
using ComView.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace ComView.Controllers
{
    [Route("api/days")]
    [ApiController]
    public class DaysController : ControllerBase { 
    
        private readonly IDayRepo _repository;
        private readonly IMapper _mapper;

        public DaysController(IDayRepo dayRepo, IMapper mapper)
        {
            _repository = dayRepo;
            _mapper = mapper;

        }
        // GET: api/<DaysController>
        [HttpGet]
        public ActionResult<IEnumerable<Day>> GetList()
        {
            var days = _repository.GetDayList();

            return Ok(_mapper.Map<IEnumerable<DayReadDto>>(days));
        }

        // GET api/<DaysController>/5
        [HttpGet("{id}", Name = "GetDay")]
        public ActionResult<DayReadDto> GetDay(int id)
        {
            var day = _repository.GetDayById(id);
            if (day != null)
            {
                return Ok(_mapper.Map<DayReadDto>(day));
            }
            else
                return NotFound();

        }

        // POST api/<DayController>
        [HttpPost]
        public ActionResult<DayReadDto> Post([FromBody] DayCreateDto createDto)
        {
            var day = _mapper.Map<Day>(createDto);
            _repository.CreateDay(day);
            _repository.SaveChanges();
            var readDto = _mapper.Map<DayReadDto>(day);
            return CreatedAtRoute(nameof(GetDay), new { Id = readDto.Id }, readDto);
        }

        // PUT api/<DayController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DayUpdateDto dayUpdateDto)
        {
            var dayToUpdate = _repository.GetDayById(id);
            if (dayToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(dayUpdateDto, dayToUpdate);
            _repository.UpdateDay(dayToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }
        // PATCH api/<DayController>/5
        [HttpPatch]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<DayUpdateDto> jsonPatchDocument)
        {
            var dayToUpdate = _repository.GetDayById(id);
            if (dayToUpdate == null)
            {
                return NotFound();
            }
            var dayToPatch = _mapper.Map<DayUpdateDto>(dayToUpdate);
            jsonPatchDocument.ApplyTo(dayToPatch, ModelState);
            if (!TryValidateModel(dayToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(dayToPatch, dayToUpdate);
            _repository.UpdateDay(dayToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/<DayController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var dayToDelete = _repository.GetDayById(id);
            if (dayToDelete == null)
            {
                return NotFound();
            }
            _repository.DeleteDay(dayToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
