using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Dtos;
using Todo.Models;

namespace Todo.Mappers
{
    // Mapper sınıfları iki farklı sınıf arasında veri transferi yaparken kullanılır.
    public static class ProductMapper
    {
        // this ProductDto productDto ifadesi ile bu metot artık ProductDto sınıfının bir metodu gibi kullanılabilir.
        public static Product MapToProduct(this ProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Category = productDto.Category,
                Price = productDto.Price,
                BarcodeNo = productDto.Name?.Substring(0, 3).ToUpper() + productDto.Category?.Substring(0, 3).ToUpper() +"-"+ new Random().Next(1000, 9999)
            };
        }
    }
}