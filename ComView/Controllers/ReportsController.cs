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
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepo _repository;
        private readonly IMapper _mapper;

        public ReportsController(IReportRepo reportRepo, IMapper mapper)
        {
            _repository = reportRepo;
            _mapper = mapper;

        }
        // GET: api/<ReportController>
        [HttpGet]
        public ActionResult<IEnumerable<Report>> GetList()
        {
            var reports = _repository.GetReportList();

            return Ok(_mapper.Map<IEnumerable<ReportReadDto>>(reports));
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}", Name = "GetReport")]
        public ActionResult<ReportReadDto> GetReport(int id, [FromQuery(Name = "dayId")] int? dayIdString, [FromQuery(Name ="productId")] int? productIdString)
        {
            int dayId = Convert.ToInt32(dayIdString);
            int productId = Convert.ToInt32(productIdString);
            Report report;
            if (dayId == 0 && productId == 0)
            {
                report = _repository.GetReportById(id);
            }
            else
            {
                report = _repository.GetReportById(id, dayId, productId);
            }
                
            if (report != null)
            {
                return Ok(_mapper.Map<ReportReadDto>(report));
            }
            else
                return NotFound();

        }
        // POST api/<ReportController>
        [HttpPost]
        public ActionResult<ReportReadDto> Post([FromBody] ReportCreateDto createDto)
        {
            var report = _mapper.Map<Report>(createDto);
            _repository.CreateReport(report);
            _repository.SaveChanges();
            var readDto = _mapper.Map<ReportReadDto>(report);
            return CreatedAtRoute(nameof(GetReport), new { Id = readDto.Id }, readDto);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ReportUpdateDto reportUpdateDto)
        {
            var reportToUpdate = _repository.GetReportById(id);
            if (reportToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(reportUpdateDto, reportToUpdate);
            _repository.UpdateReport(reportToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }
        // PATCH api/<ReportController>/5
        [HttpPatch]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<ReportUpdateDto> jsonPatchDocument)
        {
            var reportToUpdate = _repository.GetReportById(id);
            if (reportToUpdate == null)
            {
                return NotFound();
            }
            var reportToPatch = _mapper.Map<ReportUpdateDto>(reportToUpdate);
            jsonPatchDocument.ApplyTo(reportToPatch, ModelState);
            if (!TryValidateModel(reportToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(reportToPatch, reportToUpdate);
            _repository.UpdateReport(reportToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var reportToDelete = _repository.GetReportById(id);
            if (reportToDelete == null)
            {
                return NotFound();
            }
            _repository.DeleteReport(reportToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
