// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations
{
    internal class DatabaseInformationConfiguration : IEntityTypeConfiguration<DatabaseInformation>
    {
        public void Configure(EntityTypeBuilder<DatabaseInformation> builder)
        {
            builder.ToTable("database_information");

            builder.HasNoKey();

            builder.Property(i => i.DatabaseVersion)
                   .HasColumnName("database_version");
        }
    }
}
