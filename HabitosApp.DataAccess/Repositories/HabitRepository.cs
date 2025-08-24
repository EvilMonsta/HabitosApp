using Habitos.Core.Models;
using Habitos.Core.Repositories;
using Habitos.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Habitos.DataAccess.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly HabitosDbContext _context;

        public HabitRepository(HabitosDbContext context) 
        {
            _context = context;    
        }

        public async Task AddOrUpdateEntryAsync(Guid habitId, DateTime date, int increment, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Habit habit, CancellationToken token)
        {
            var name = habit.Name.Trim();
            var exists = await _context.Habits
                .AsNoTracking()
                .AnyAsync(h => h.UserId == habit.UserId && h.Name.ToLower() == name.ToLower(), token);

            if (exists)
                throw new InvalidOperationException("Имя привычки уже занято у этого пользователя.");

            var entity = HabitMapper.ToEntity(habit);

            await _context.Habits.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
        }

        public Task DeleteByIdAsync(Guid habitId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<Habit?> GetByIdAsync(Guid id, CancellationToken token)
        {
            var entity = await _context.Habits
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id, token);

            if (entity is null) return null;

            return HabitMapper.ToDomain(entity);
        }

        public async Task<IReadOnlyList<HabitEntry>> GetEntriesForPeriodAsync(Guid habitId, DateTime from, DateTime to, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Habit>> GetListAsync(Guid userId, bool includeArchived, int page, int pageSize, string sortBy, bool sortDescending, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Habit?> GetWithEntriesByIdAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HabitNameExistsAsync(Guid userId, string name, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCompletedForTodayAsync(Guid habitId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Habit habit, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
