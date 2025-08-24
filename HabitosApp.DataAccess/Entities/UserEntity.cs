using Habitos.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Habitos.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public bool IsPremium { get; set; }

        public string? Title { get; set; }

        public string? AvatarUrl { get; set; }

        public ICollection<HabitEntity> Habits { get; set; } = new List<HabitEntity>();
    }
}