using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitos.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Habitos.DataAccess
{
    public class HabitosDbContext : DbContext
    {
        public HabitosDbContext(DbContextOptions<HabitosDbContext> options) : base(options) { }
    
        public DbSet<HabitEntity> Habits { get; set; }
            
    }
}
