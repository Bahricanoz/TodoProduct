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
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTodo(TodoItem todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem?> DeleteTodo(int id)
        {
            var todo = _context.Todos.Find(id);
            if(todo == null){
                return null;
            }
            _context.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<List<TodoItem>> GetAllTodos()
        {
            // "Select * From Todos"
           return await _context.Todos.ToListAsync();
        }

        public async Task<TodoItem?> GetTodoById(int id)
        {
            // "Select * From Todos Where Id = id"
            var todo = await _context.Todos.FindAsync(id);
            if(todo == null){
                return null;
            }
            return todo;
        }

        public async Task<TodoItem?> UpdateTodo(int id ,TodoItem todo)
        {
          
            var todoItem = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if(todoItem == null){
                return null;
            }
            todoItem.Name = todo.Name;
            todoItem.Date = todo.Date;
            todoItem.IsComplete = todo.IsComplete;
            await _context.SaveChangesAsync();
            return todoItem;
        }
    }
}