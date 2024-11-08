using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Interface;

namespace Todo.Services
{
    public class NotificationService : INotificationService
    {
        public void GenerateReport()
        {
            Console.WriteLine("Report generated");
        }

        public void SendNotification(string process)
        {
            Console.WriteLine($"Notification sent for {process}");
        }
    }
}