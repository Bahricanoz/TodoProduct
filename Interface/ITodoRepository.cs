using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Interface
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllTodos();
        Task CreateTodo(TodoItem todo);
        Task<TodoItem?> DeleteTodo(int id);
        Task<TodoItem?> GetTodoById(int id);
        Task<TodoItem?> UpdateTodo(int id,TodoItem todo);
    }
}