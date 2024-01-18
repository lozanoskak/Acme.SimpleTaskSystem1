using Acme.SimpleTaskSystem.People;
using Acme.SimpleTaskSystem.Tasks;
using Acme.SimpleTaskSystem.Users;
using System;

namespace Acme.SimpleTaskSystem.Web.Models.Tasks
{
    public class DetailsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
    }
}
