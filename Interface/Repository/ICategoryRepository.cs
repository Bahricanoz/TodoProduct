using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Interface.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task CreateCategory(Category category);
    }
}