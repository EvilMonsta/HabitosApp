using Habitos.Core.Models;
using Habitos.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Habitos.DataAccess.Mapping
{
    public class HabitEntryMapper
    {
        public static HabitEntry ToDomain(HabitEntryEntity entity) =>
            HabitEntry.Restore(
                entity.Id,
                entity.HabitId,
                entity.Date,
                entity.TimesCompleted,
                entity.CreatedAt
            );

        public static HabitEntryEntity ToEntity(HabitEntry entry) => 
            new HabitEntryEntity
            {
                Id = entry.Id,
                HabitId = entry.HabitId,
                Date = entry.Date,
                TimesCompleted = entry.TimesCompleted,
                CreatedAt = entry.CreatedAt
            };
    }
}
