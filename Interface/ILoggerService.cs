using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Interface
{
    public interface ILoggerService
    {
        void Write(string message);
    }
}