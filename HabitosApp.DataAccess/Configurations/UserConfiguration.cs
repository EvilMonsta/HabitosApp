using Habitos.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(Habitos.Core.Models.User.MAX_NAME_LENGTH);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(Habitos.Core.Models.User.MAX_NAME_LENGTH);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(Habitos.Core.Models.User.MAX_NAME_LENGTH);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.IsPremium)
                .IsRequired();

            builder.Property(x => x.Title);

            builder.Property(x => x.AvatarUrl);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasMany(x => x.Habits)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
