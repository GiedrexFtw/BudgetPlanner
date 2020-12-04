using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProductList();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        bool SaveChanges();
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

    }
}
