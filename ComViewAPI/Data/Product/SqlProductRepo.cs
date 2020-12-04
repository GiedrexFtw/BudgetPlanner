using ComView.Models;
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

        public Product GetProductById(int id)
        {
            return _appContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductList()
        {
            return _appContext.Products.ToList();
        }

        public bool SaveChanges()
        {
            return _appContext.SaveChanges() >= 0;
        }

        public void UpdateProduct(Product product)
        {
            //
        }
    }
}
