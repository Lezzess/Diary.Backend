using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Context
{
    internal class ApplicationContext : DbContext
    {
        #region Properties

        public DbSet<DatabaseInformation> DatabaseInformation { get; set; }
        public DbSet<DiaryEntity> Diaries { get; set; }

        #endregion

        #region Constructors

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        #endregion
    }
}
