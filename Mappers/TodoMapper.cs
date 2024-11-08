using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Dtos;
using Todo.Mappers;
using Todo.Models;

namespace Todo.Mappers
{
    public static class TodoMapper
    {
        public static TodoItem MapToTodoItem(this TodoDto todoDto)
        {
            return new TodoItem
            {
                Name = todoDto.Name,
                Date = todoDto.Date,
                IsComplete = todoDto.IsComplete
            };
        }
    }
}

