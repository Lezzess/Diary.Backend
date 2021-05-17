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
