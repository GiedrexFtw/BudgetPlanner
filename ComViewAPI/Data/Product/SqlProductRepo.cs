using ComView.Dto;
using ComView.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly ApplicationContext _appContext;

        public SqlProductRepo(ApplicationContext productContext)
        {
            _appContext = productContext;
        }
        public IEnumerable<ProductReadDto> GetProductList()
        {
            return _appContext.Products.Select(pr => new ProductReadDto
            {
                Id = pr.Id,
                Title = pr.Title,
                Description = pr.Description,
                Amount = pr.Amount,
                DayId = pr.DayId,
                DayDate = pr.Day.Date,
                CategoryId = pr.CategoryId,
                CategoryName = pr.Category.Title
            }).ToList();
        }
        public IEnumerable<ProductReadDto> GetProductList(int userId)
        {
            return _appContext.Products.Where(p => p.UserId == userId).Select(pr => new ProductReadDto
            {
                Id=pr.Id,
                Title =pr.Title,
                Description =pr.Description,
                Amount =pr.Amount,
                DayId =pr.DayId,
                DayDate=pr.Day.Date,
                CategoryId=pr.CategoryId,
                CategoryName=pr.Category.Title
            }).ToList();
        }
        public ProductReadDto GetReadDtoById(int id)
        {
            var product = _appContext.Products.Include(x => x.Category).Include(x=>x.Day).FirstOrDefault(x => x.Id == id);
            if (product==null)
            {
                return null;
            }

            return new ProductReadDto
            {
                Id = product.Id,
                Title = product.Title,
                Amount = product.Amount,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Title,
                DayDate = product.Day.Date,
                DayId = product.DayId
            };
        }
        public ProductReadDto GetReadDtoById(int id, int userId)
        {
            var product = _appContext.Products.Include(x => x.Category).Include(x => x.Day).FirstOrDefault(x => x.Id == id && x.UserId == userId);
            if (product == null)
            {
                return null;
            }

            return new ProductReadDto
            {
                Id = product.Id,
                Title = product.Title,
                Amount = product.Amount,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Title,
                DayDate = product.Day.Date,
                DayId = product.DayId
            };
        }
        public void CreateProduct(Product product)
        {
            if (product != null)
            {
                _appContext.Products.Add(product);
            }
            else
                throw new ArgumentException();
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }
            _appContext.Products.Remove(product);
            
        }

        public bool SaveChanges()
        {
            return _appContext.SaveChanges() >= 0;
        }

        public void UpdateProduct(Product product)
        {
            //
        }

        public Product GetProductById(int id)
        {
            return _appContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductById(int id, int userId)
        {
            return _appContext.Products.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        }
    }
}
