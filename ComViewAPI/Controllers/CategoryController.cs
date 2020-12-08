using AutoMapper;
using ComViewAPI.Data;
using ComViewAPI.Dto.Category;
using ComViewAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComViewAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _repository = categoryRepo;
            _mapper = mapper;

        }
        // GET: api/<CategoryController>
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetList()
        {
            var categories = _repository.GetCategoryList();

            return Ok(_mapper.Map<IEnumerable<CategoryReadDto>>(categories));
        }

        // GET api/<CategoryController>/5
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<CategoryReadDto> GetCategory(int id)
        {
            var category = _repository.GetCategoryById(id);
            if (category != null)
            {
                return Ok(_mapper.Map<CategoryReadDto>(category));
            }
            else
                return NotFound();

        }

        // POST api/<CategoryController>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult<CategoryReadDto> Post([FromBody] CategoryCreateDto createDto)
        {
            var category = _mapper.Map<Category>(createDto);
            _repository.CreateCategory(category);
            _repository.SaveChanges();
            var readDto = _mapper.Map<CategoryReadDto>(category);
            return CreatedAtRoute(nameof(GetCategory), new { Id = readDto.Id }, readDto);
        }

        // PUT api/<CategoryController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var categoryToUpdate = _repository.GetCategoryById(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryUpdateDto, categoryToUpdate);
            _repository.CheckProducts(categoryToUpdate);
            _repository.UpdateCategory(categoryToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }
        // PATCH api/<CategoryController>/5
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<CategoryUpdateDto> jsonPatchDocument)
        {
            var categoryToUpdate = _repository.GetCategoryById(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }
            var categoryToPatch = _mapper.Map<CategoryUpdateDto>(categoryToUpdate);
            jsonPatchDocument.ApplyTo(categoryToPatch, ModelState);
            if (!TryValidateModel(categoryToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(categoryToPatch, categoryToUpdate);
            _repository.UpdateCategory(categoryToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoryToDelete = _repository.GetCategoryById(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(categoryToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
