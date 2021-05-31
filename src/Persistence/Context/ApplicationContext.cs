using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Context
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<DatabaseInformation> DatabaseInformation { get; set; }
        public DbSet<DiaryEntity> Diaries { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
    }
}
