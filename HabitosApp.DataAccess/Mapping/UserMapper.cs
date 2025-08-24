using Habitos.Core.Models;
using Habitos.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.DataAccess.Mapping
{
    public class UserMapper
    {
        public static User ToDomain(UserEntity entity) =>
            User.Restore(
                entity.Id,
                entity.Email,
                entity.PasswordHash,
                entity.FullName,
                entity.CreatedAt,
                entity.IsPremium,
                entity.Habits.Select(h => HabitMapper.ToDomain(h)).ToList()
            );

        public static UserEntity ToEntity(User user) =>
            new UserEntity
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                FullName = user.FullName,
                CreatedAt = user.CreatedAt,
                IsPremium = user.IsPremium,
                Habits = user.Habits.Select(h => HabitMapper.ToEntity(h)).ToList()
            };
    }
}