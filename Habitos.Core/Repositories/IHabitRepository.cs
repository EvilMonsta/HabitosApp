using Habitos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Habitos.Core.Repositories
{
    public interface IHabitRepository
    {
        Task<Habit?> GetByIdAsync(Guid id, CancellationToken token);

        Task<Habit?> GetWithEntriesByIdAsync(Guid id, CancellationToken token);

        Task<IReadOnlyList<Habit>> GetListAsync(
            Guid userId,
            bool includeArchived,
            int page,
            int pageSize,
            string sortBy,
            bool sortDescending,
            CancellationToken token = default);

        Task CreateAsync(Habit habit, CancellationToken token);

        Task UpdateAsync(Habit habit, CancellationToken token);

        Task DeleteByIdAsync(Guid habitId, CancellationToken token);

        Task<bool> IsCompletedForTodayAsync(Guid habitId, CancellationToken token);

        Task<bool> HabitNameExistsAsync(Guid userId, string name, CancellationToken token);

        Task AddOrUpdateEntryAsync(Guid habitId, DateTime date, int increment, CancellationToken token);

        Task<IReadOnlyList<HabitEntry>> GetEntriesForPeriodAsync(Guid habitId, DateTime from, DateTime to, CancellationToken token);

    }
}
