using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Interface;

namespace Todo.Services
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void Write(string message)
        {
           Console.WriteLine(message);
        }
    }
}