using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitos.Core.Models;
using Habitos.DataAccess.Entities;

namespace Habitos.DataAccess.Entities
{
    public class HabitEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int TimesPerDay { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsArchived { get; set; } = false;

        public Guid UserId { get; set; }

        public required UserEntity User { get; set; }

        public ICollection<HabitEntryEntity> Entries { get; set; } = new List<HabitEntryEntity>();

    }
}
