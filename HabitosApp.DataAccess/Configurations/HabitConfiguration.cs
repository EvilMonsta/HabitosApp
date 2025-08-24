using Habitos.DataAccess.Entities;
using Habitos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitos.DataAccess.Configurations
{
    public class HabitConfiguration : IEntityTypeConfiguration<HabitEntity>
    {
        public void Configure(EntityTypeBuilder<HabitEntity> builder)
        {

            builder.ToTable("habits", t =>
            {
                t.HasCheckConstraint(
                    "ck_habits_timesperday_positive",
                    "\"TimesPerDay\" > 0"
                );
            });

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Habitos.Core.Models.Habit.MAX_NAME_LENGTH);

            builder.Property(x => x.Description)
                .HasMaxLength(Habitos.Core.Models.Habit.MAX_DESCR_LENGTH);

            builder.Property(x => x.TimesPerDay)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");

            builder.Property(x => x.IsArchived)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasIndex(x => new 
            {  
                x.UserId, x.Name 
            })
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(u => u.Habits)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Entries)
                .WithOne(e => e.Habit)
                .HasForeignKey(e => e.HabitId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
