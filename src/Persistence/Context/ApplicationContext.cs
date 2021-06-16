// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

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
