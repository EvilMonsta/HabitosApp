using Habitos.DataAccess.Entities;
using Habitos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.DataAccess.Mapping
{
    public class HabitMapper
    {
        public static Habit ToDomain(HabitEntity entity) => 
            Habit.Restore(
                entity.Id,
                entity.Name,
                entity.Description,
                entity.TimesPerDay,
                entity.StartDate,
                entity.IsArchived,
                entity.UserId,
                entity.Entries.Select(e => HabitEntryMapper.ToDomain(e)).ToList()
            );

        public static HabitEntity ToEntity(Habit habit) => 
            new HabitEntity
            {
                Id = habit.Id,
                Name = habit.Name,
                Description = habit.Description,
                TimesPerDay = habit.TimesPerDay,
                StartDate = habit.StartDate,
                IsArchived = habit.IsArchived,
                UserId = habit.UserId,
                User = null!,
                Entries = habit.Entries.Select(HabitEntryMapper.ToEntity).ToList()
            };
    }
}
