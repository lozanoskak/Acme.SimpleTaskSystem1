using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Acme.SimpleTaskSystem.Events;
using Acme.SimpleTaskSystem.Hubs;
using Acme.SimpleTaskSystem.Tasks.Dtos;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.EventHandlers
{
    public class TaskModifiedEventHandler : IEventHandler<TaskModifiedEventData>, ITransientDependency
    {
        //private readonly IHubContext<TaskHub, ITaskHub> _hubContext;
        private readonly IHubContext<TaskHub> _hubContext;

        //public TaskModifiedEventHandler(IHubContext<TaskHub, ITaskHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}
        public TaskModifiedEventHandler(IHubContext<TaskHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async void HandleEvent(TaskModifiedEventData eventData)
        {
            Console.WriteLine("Handling event");
            
            await _hubContext.Clients.All.SendAsync("UpdateTask", eventData);

        }
    }
}
