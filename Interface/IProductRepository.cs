using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Interface
{
    // İnterfaceler İmza niteliği taşırlar. Yani içerisinde metotlar tanımlanır fakat metotların içi dolu değildir.
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task AddProduct(Product product);
        Task<Product?> GetProductById(int id);
        Task<Product?> DeleteProduct(int id);
        Task<Product?> UpdateProduct(int id, Product product);
    }
}