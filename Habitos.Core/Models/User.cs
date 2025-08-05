using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habituso.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsPremium { get; set; } = false;

        public string? Title { get; set; } = null;          

        public string? AvatarUrl { get; set; } = null;

        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
    }

}
