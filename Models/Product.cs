using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    // Entityler veritabanındaki tabloları temsil ederler.
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public string? BarcodeNo { get; set; }

        public Product(){
            // Constructor metot yapıcı metotlar olarak adlandırılır.
            // Constructor metotlar nesne oluşturulduğunda çalışan metotlardır.
            
        }
    }
}