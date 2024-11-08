using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class TodoItem
    {
        public int Id {get; set;}
        public string? Name{get;set;}  
        public string? Date {get;set;}
        public bool IsComplete{get;set;}
    }
}