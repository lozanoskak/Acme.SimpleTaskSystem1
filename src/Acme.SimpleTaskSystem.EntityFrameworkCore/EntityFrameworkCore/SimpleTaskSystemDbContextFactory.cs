using Acme.SimpleTaskSystem.Configuration;
using Acme.SimpleTaskSystem.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.SimpleTaskSystem.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class SimpleTaskSystemDbContextFactory : IDesignTimeDbContextFactory<SimpleTaskSystemDbContext>
    {
        public SimpleTaskSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SimpleTaskSystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(SimpleTaskSystemConsts.ConnectionStringName)
            );

            return new SimpleTaskSystemDbContext(builder.Options);
        }
    }
}