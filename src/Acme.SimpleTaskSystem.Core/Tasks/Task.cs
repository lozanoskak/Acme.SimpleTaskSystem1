using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.SimpleTaskSystem.People;
using Acme.SimpleTaskSystem.Base;

namespace Acme.SimpleTaskSystem.Tasks
{

    [Table("AppTasks")]
    public class Task :BaseEntity
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;

        public Person AssignedPerson { get; set; }
        public Guid? AssignedPersonId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }


        public TaskState State { get; set; }

        public Task()
        {
            State = TaskState.Open;
        }

        public Task(string title, string description = null, Guid? assignedPersonId=null)
            : this()
        {
            Title = title;
            Description = description;
            AssignedPersonId = assignedPersonId;
        }
    }
}
