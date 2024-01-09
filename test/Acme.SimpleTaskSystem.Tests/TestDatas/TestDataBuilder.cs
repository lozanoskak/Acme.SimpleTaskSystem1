using Abp.Threading.BackgroundWorkers;
using Acme.SimpleTaskSystem.EntityFrameworkCore;
using Acme.SimpleTaskSystem.People;
using Acme.SimpleTaskSystem.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Acme.SimpleTaskSystem.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly SimpleTaskSystemDbContext _context;

        public TestDataBuilder(SimpleTaskSystemDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            var neo = new Person("Neo");
            _context.People.Add(neo);
            _context.SaveChanges();
            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality"),
                new Task("Clean your room") { State = TaskState.Completed });
            //create test data here...
        }
    }
}