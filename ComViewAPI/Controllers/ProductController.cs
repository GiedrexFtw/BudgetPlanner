using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ComView.Data;
using ComView.Dto;
using ComView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComView.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo productRepo, IMapper mapper)
        {
            _repository = productRepo;
            _mapper = mapper;

        }
        // GET: api/<ProductController>
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetList()
        {
            
            var identif = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            if(identif == 0)
            {
                return Unauthorized();
            }
            IEnumerable<ProductReadDto> products;
            switch (role)
            {
                case "User":
                    products = _repository.GetProductList(identif);
                    break;
                case "Admin":
                    products = _repository.GetProductList();
                    break;
                default:
                    return Unauthorized();
            }
            
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<ProductReadDto> GetProduct(int id)
        {
            var identif = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            if (identif == 0)
            {
                return Unauthorized();
            }
            ProductReadDto product;
            switch (role)
            {
                case "User":
                    product = _repository.GetReadDtoById(id);
                    break;
                case "Admin":
                    product = _repository.GetReadDtoById(id, identif);
                    break;
                default:
                    return Unauthorized();
            }
            if (product != null)
            {
                return Ok(product);
            }
            else
                return NotFound();
        }

        // POST api/<ProductController>
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult<ProductReadDto> Post([FromBody]ProductCreateDto createDto)
        {
            var product = _mapper.Map<Product>(createDto);
            var identif = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if(identif == 0)
            {
                return Unauthorized();
            }
            product.UserId = identif;
            _repository.CreateProduct(product);
            _repository.SaveChanges();
            var readDto = _mapper.Map<ProductReadDto>(product);

            return CreatedAtRoute(nameof(GetProduct), new {Id = readDto.Id }, readDto);
        }

        // PUT api/<ProductController>/5
        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            var productToUpdate = _repository.GetProductById(id);
            if(productToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(productUpdateDto, productToUpdate);
            _repository.UpdateProduct(productToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }
        // PATCH api/<ProductController>/5
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<ProductUpdateDto> jsonPatchDocument)
        {
            var productToUpdate = _repository.GetProductById(id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            var productToPatch = _mapper.Map<ProductUpdateDto>(productToUpdate);
            jsonPatchDocument.ApplyTo(productToPatch, ModelState);
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(productToPatch, productToUpdate);
            _repository.UpdateProduct(productToUpdate);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var productToDelete = _repository.GetProductById(id);
            if (productToDelete == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(productToDelete);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
