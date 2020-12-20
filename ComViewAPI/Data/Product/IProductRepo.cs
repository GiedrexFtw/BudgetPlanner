using ComView.Dto;
using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public interface IProductRepo
    {
        IEnumerable<ProductReadDto> GetProductList();
        IEnumerable<ProductReadDto> GetProductList(int userId);
        ProductReadDto GetReadDtoById(int id);
        ProductReadDto GetReadDtoById(int id, int userId);
        Product GetProductById(int id);
        Product GetProductById(int id, int userId);
        void CreateProduct(Product product);
        bool SaveChanges();
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

    }
}
