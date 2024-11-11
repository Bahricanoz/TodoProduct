using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Task CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}