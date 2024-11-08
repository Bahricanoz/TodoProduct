using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Dtos
{
    public class TodoDto
    {
        public string? Name { get; set; }
        public string? Date { get; set; }
        public bool IsComplete { get; set; }
    }
}