using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Acme.SimpleTaskSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Acme.SimpleTaskSystem.Events
{
    public class TaskModifiedEventData : EntityEventData<Task>
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskModifiedEventData(Task entity):base(entity)
        {
            TaskId = entity.Id;
            Title = entity.Title;
            Description = entity.Description; ;
        }
        
    }
}
