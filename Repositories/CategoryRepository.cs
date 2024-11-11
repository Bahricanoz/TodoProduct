using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Interface.Repository;
using Todo.Models;

namespace Todo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}