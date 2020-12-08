using ComViewAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComViewAPI.Data
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetCategoryList();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        bool SaveChanges();
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void CheckProducts(Category categoryToUpdate);
    }
}
