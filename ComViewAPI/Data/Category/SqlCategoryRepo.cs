using ComView.Data;
using ComView.Models;
using ComViewAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComViewAPI.Data
{
    public class SqlCategoryRepo : ICategoryRepo
    {
        private readonly ApplicationContext _appContext;

        public SqlCategoryRepo(ApplicationContext categoryContext)
        {
            _appContext = categoryContext;
        }

        public void CheckProducts(Category categoryToUpdate)
        {
            ICollection<Product> collection = new List<Product>();
            //var newProduct = categoryToUpdate.Products.Where(x => x.Id == 0);
            foreach (var item in categoryToUpdate.Products)
            {
                if (item.Id == 0)
                {
                    collection.Add(item);
                }
            }
            categoryToUpdate.Products.Clear();
            foreach (var item in collection)
            {
                categoryToUpdate.Products.Add(item);
            }

        }

        public void CreateCategory(Category category)
        {
            if (category != null)
            {
                _appContext.Categories.Add(category);
            }
            else
                throw new ArgumentException();
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            _appContext.Categories.Remove(category);

        }

        public Category GetCategoryById(int id)
        {
            var category = _appContext.Categories.Include(d => d.Products).FirstOrDefault(p => p.Id == id);
            //var products = _appContext.Categorys.
            return category;
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _appContext.Categories.Include(d => d.Products).ToList();
        }

        public bool SaveChanges()
        {
            return _appContext.SaveChanges() >= 0;
        }

        public void UpdateCategory(Category category)
        {
            //
        }
    }
}
