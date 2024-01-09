using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.Base
{
    public class BaseEntity:Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        public  int? CreatorId { get; set; }
        public int LastUpdatedById { get; set; } 
        public DateTime LastUpdatedTime { get; set; }
        public int DelitedBy { get; set; }
        public DateTime DelitedTime { get; set; }

        public BaseEntity()
        {
            CreationTime = DateTime.Now;
            LastUpdatedTime = CreationTime;
        }

    }
}
