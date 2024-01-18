using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Acme.SimpleTaskSystem.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.Tasks.Dtos
{
    [AutoMap(typeof(Task))]
    public class TaskDetailsDto 
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
