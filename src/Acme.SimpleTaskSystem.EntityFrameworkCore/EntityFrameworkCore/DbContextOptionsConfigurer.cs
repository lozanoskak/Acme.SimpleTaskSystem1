using Microsoft.EntityFrameworkCore;

namespace Acme.SimpleTaskSystem.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<SimpleTaskSystemDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for SimpleTaskSystemDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
