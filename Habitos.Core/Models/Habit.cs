using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habituso.Core.Models
{
    public class Habit
    {
        public Guid Id { get; set; } = Guid.NewGuid();       
        
        public string Name { get; set; } = string.Empty;     
        
        public string? Description { get; set; }                    

        public int TimesPerDay { get; set; } = 1;                  

        public DateTime StartDate { get; set; } = DateTime.UtcNow; 

        public bool IsArchived { get; set; } = false;               

        public Guid UserId { get; set; }             
        
        public User? User { get; set; }                             

        public ICollection<HabitEntry> Entries { get; set; } = new List<HabitEntry>();
    }
}
