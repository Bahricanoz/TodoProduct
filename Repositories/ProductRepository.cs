using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Interface;
using Todo.Models;

namespace Todo.Repositories
{
    //  Veritabanı işlemleri burada yapılır.
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context; // veritabanı işlemleri için context nesnesi oluşturuldu. Prodcut tablosuna erişebilmek için.
        public ProductRepository(ApplicationDbContext context) // constructor metota bağımlığı enjekte edildi. // bunu getter setterda yapbilirsiniz
        {
            _context = context;
        }
        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            // Insert Into Products (Name, Category, Price, BarcodeNo) Values ('Kalem', 'Kırtasiye', 10, '1234567890')
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product =await _context.Products.FindAsync(id);
            if(product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(int id, Product product)
        {
            var productItem = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(productItem == null)
            {
                return null;
            }
            productItem.Name = product.Name;
            productItem.Category = product.Category;
            productItem.Price = product.Price;
            productItem.BarcodeNo = product.Name?.Substring(0, 3).ToUpper() + product.Category?.Substring(0, 3).ToUpper() + "-" + new Random().Next(1000, 9999);
            await _context.SaveChangesAsync();
            return productItem;
        }
    }
}