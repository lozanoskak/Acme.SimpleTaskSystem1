﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.Tasks.Dtos
{
    [AutoMapFrom(typeof(Task))]
    public class TaskListDto:EntityDto, IHasCreationTime
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public TaskState State { get; set; }
        public Guid? AssignedPersonId { get; set; }
        public string AssignedPersonName { get; set; }
        public string TestDbMigtrasyion { get; set; }
    }
}
