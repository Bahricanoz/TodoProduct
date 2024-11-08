using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Models;


namespace Todo.Data
{
    // veritabanında yansıtılacak tabloların tanımlandığı sınıf.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }  
        public DbSet<Product> Products { get; set; }

        Product product = new Product();
        
        
    }
    // migrations işlemi her yeni entityde yapılmalıdır.
    // dotnet ef migrations add (anlamlı bir adı)
    // dotnet ef database update bunu yaparak veritabanına yansıtılır.
}