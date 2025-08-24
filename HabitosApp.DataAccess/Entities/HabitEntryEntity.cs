using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.DataAccess.Entities
{
    public class HabitEntryEntity
    {
        public Guid Id { get;  set; } = Guid.NewGuid();

        public Guid HabitId { get;  set; }

        public HabitEntity? Habit { get;  set; }

        public DateTime Date { get;  set; }

        public int TimesCompleted { get;  set; } = 1;

        public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;
    }
}
