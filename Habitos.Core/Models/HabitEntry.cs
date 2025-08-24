using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.Core.Models
{
    public class HabitEntry
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid HabitId { get; private set; }            
        
        public Habit? Habit { get; private set; }

        public DateTime Date { get; private set; }             
        
        public int TimesCompleted { get; private set; } = 1;            

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
        private HabitEntry() { }

        public static HabitEntry Create(Guid habitId, DateTime date, int timesCompleted = 1)
        {
            if (habitId == Guid.Empty)
                throw new ArgumentException("Идентификатор привычки обязателен.");
            if (timesCompleted <= 0)
                throw new ArgumentException("Количество выполнений должно быть больше 0.");
            return new HabitEntry
            {
                Id = Guid.NewGuid(),
                HabitId = habitId,
                Date = date.Date,
                TimesCompleted = timesCompleted,
                CreatedAt = DateTime.UtcNow
            };
        }

        public void AddCompletion(int count = 1)
        {
            if (count <= 0)
                throw new ArgumentException("Нельзя добавить 0 или отрицательное число.");

            TimesCompleted += count;
        }

        public void Reset()
        {
            TimesCompleted = 0;
        }

        public static HabitEntry Restore(Guid id, Guid habitId, DateTime date, int timesCompleted, DateTime createdAt)
        {
            return new HabitEntry
            {
                Id = id,
                HabitId = habitId,
                Date = date,
                TimesCompleted = timesCompleted,
                CreatedAt = createdAt
            };
        }
    }
}
