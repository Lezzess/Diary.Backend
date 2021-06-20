// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class DiaryConfiguration : IEntityTypeConfiguration<Diary>
    {
        public void Configure(EntityTypeBuilder<Diary> builder)
        {
            builder.ToTable("diaries");

            builder.Property(d => d.Id)
                   .HasColumnName("id");

            builder.Property(d => d.Title)
                   .HasColumnName("title");

            builder.Property(d => d.Description)
                   .HasColumnName("description");
        }
    }
}
