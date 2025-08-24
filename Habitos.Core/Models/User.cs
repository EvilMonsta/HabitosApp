using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.Core.Models
{
    public class User
    {

        public const int MAX_NAME_LENGTH = 100;

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Email { get; private set; } = string.Empty;

        public string PasswordHash { get; private set; } = string.Empty;

        public string FullName { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public bool IsPremium { get; private set; } = false;

        public string? Title { get; private set; } = null;          

        public string? AvatarUrl { get; private set; } = null;

        public ICollection<Habit> Habits { get; private set; } = new List<Habit>();

        private User() { }

        public static User Create(string email, string passwordHash, string fullName, bool isPremium = false, string? title = null, string? avatarUrl = null)
        {
            if (fullName.Length > MAX_NAME_LENGTH)
                throw new ArgumentException($"Полное имя не может превышать {MAX_NAME_LENGTH} символов.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Электронная почта не может быть пустой.");
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Пароль не может быть пустым.");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Полное имя не может быть пустым.");
            return new User
            {
                Id = Guid.NewGuid(),
                Email = email.Trim(),
                PasswordHash = passwordHash.Trim(),
                FullName = fullName.Trim(),
                IsPremium = isPremium,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public static User Restore(Guid id, string email, string passwordHash, string fullName, DateTime createdAt, bool isPremium, ICollection<Habit>? habits, string? title = null, string? avatarUrl = null)
        {
            return new User
            {
                Id = id,
                Email = email,
                PasswordHash = passwordHash,
                FullName = fullName,
                CreatedAt = createdAt,
                IsPremium = isPremium,
                Title = title,
                AvatarUrl = avatarUrl,
                Habits = habits?.ToList() ?? new List<Habit>()
            };
        }

        public void ChangeTitle(string? newTitle)
        {
            Title = string.IsNullOrWhiteSpace(newTitle) ? null : newTitle.Trim();
        }

        public void ChangeAvatar(string? newUrl)
        {
            AvatarUrl = string.IsNullOrWhiteSpace(newUrl) ? null : newUrl.Trim();
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Имя не может быть пустым.");

            FullName = newName.Trim();
        }

        public void EarnPremium()
        {
            IsPremium = true;
        }

        public void LosePremium()
        {
            IsPremium = false;
        }

    }

}
