using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.Core.Models
{
    public class Habit
    {
        public const int MAX_NAME_LENGTH = 100;

        public const int MAX_DESCR_LENGTH = 2000;

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = string.Empty;

        public string? Description { get; private set; }

        public int TimesPerDay { get; private set; }

        public DateTime StartDate { get; private set; }

        public bool IsArchived { get; private set; } = false;

        public Guid UserId { get; private set; }

        public ICollection<HabitEntry> Entries { get; private set; } = new List<HabitEntry>();

        private Habit() { }

        public static Habit Create(string name, int timesPerDay, Guid userId, string? description = null, DateTime? startDate = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название привычки не может быть пустым.");

            if (name.Length > MAX_NAME_LENGTH)
                throw new ArgumentException($"Название привычки не может превышать {MAX_NAME_LENGTH} символов.");

            if (description?.Length > MAX_DESCR_LENGTH)
                throw new ArgumentException($"Описание привычки не может превышать {MAX_DESCR_LENGTH} символов.");

            if (timesPerDay <= 0)
                throw new ArgumentException("Количество в день должно быть больше 0.");

            if (userId == Guid.Empty)
                throw new ArgumentException("Идентификатор пользователя обязателен.");

            return new Habit
            {
                Id = Guid.NewGuid(),
                Name = name.Trim(),
                Description = description?.Trim(),
                TimesPerDay = timesPerDay,
                StartDate = startDate ?? DateTime.UtcNow,
                UserId = userId,
            };
        }


        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Новое имя не может быть пустым.");

            Name = newName.Trim();
        }

        public static Habit Restore(Guid id, string name, string? description, int timesPerDay, DateTime startDate, bool isArchived, Guid userId, IEnumerable<HabitEntry>? entries = null)
        {
            return new Habit
            {
                Id = id,
                Name = name,
                Description = description,
                TimesPerDay = timesPerDay,
                StartDate = startDate,
                IsArchived = isArchived,
                UserId = userId,
                Entries = entries?.ToList() ?? new List<HabitEntry>()
            };
        }

        public void ChangeTimesPerDay(int newCount)
        {
            if (newCount <= 0)
                throw new ArgumentException("TimesPerDay должен быть больше 0.");

            TimesPerDay = newCount;
        }

        public void ChangeDescription(string? newDescription)
        {
            Description = newDescription?.Trim();
        }

        public void Archive()
        {
            IsArchived = true;
        }

        public void Unarchive()
        {
            IsArchived = false;
        }
    }

}
