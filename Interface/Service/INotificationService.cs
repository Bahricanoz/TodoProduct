using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Interface
{
    public interface INotificationService
    {
        void SendNotification(string process);
        void GenerateReport();
    }
}