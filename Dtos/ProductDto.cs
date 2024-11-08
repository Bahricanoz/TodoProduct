using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Dtos
{
    // Dto'lar veri transfer objeleridir. İki katman arasında veri transferi yaparken kullanılır.
    public class ProductDto
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}