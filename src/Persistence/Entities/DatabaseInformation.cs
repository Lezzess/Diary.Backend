// This is an open source non-commercial project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Entities
{
    [Table("database_information")]
    [Keyless]
    internal class DatabaseInformation
    {
        [Column("database_version")]
        public int DatabaseVersion { get; set; }
    }
}
