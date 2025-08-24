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
    internal class HabitEntryConfiguration : IEntityTypeConfiguration<HabitEntryEntity>
    {
        public void Configure(EntityTypeBuilder<HabitEntryEntity> builder)
        {
            builder.ToTable("habit_entries", t =>
            {
                t.HasCheckConstraint(
                    "ck_habit_entries_timescompleted_nonnegative",
                    "\"TimesCompleted\" >= 0"
                );
            });
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HabitId)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.TimesCompleted)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
              .IsRequired()
              .HasColumnType("timestamp with time zone");

            builder.HasIndex(x => new { x.HabitId, x.Date })
              .IsUnique();

            builder.HasOne(x => x.Habit)
              .WithMany(h => h.Entries)
              .HasForeignKey(x => x.HabitId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
