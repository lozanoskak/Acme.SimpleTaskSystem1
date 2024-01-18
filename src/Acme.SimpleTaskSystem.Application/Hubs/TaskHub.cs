using Acme.SimpleTaskSystem.Events;
using Acme.SimpleTaskSystem.Tasks.Dtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.Hubs
{
    public class TaskHub:Hub
    {
        public async Task UpdateTask(TaskModifiedEventData taskDetails)
        {
            Console.WriteLine("Task received on the hub");
            await Clients.All.SendAsync("UpdateTask", taskDetails);
        }
    }
}
