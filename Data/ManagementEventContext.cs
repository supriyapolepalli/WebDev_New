using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagementEvent.Pages.Models;

namespace ManagementEvent.Data
{
    public class ManagementEventContext : DbContext
    {
        public ManagementEventContext (DbContextOptions<ManagementEventContext> options)
            : base(options)
        {
        }

        public DbSet<ManagementEvent.Pages.Models.Event> Event { get; set; } = default!;
        public DbSet<ManagementEvent.Pages.Models.EventAttendee> EventAttendee { get; set; } = default!;
        public DbSet<ManagementEvent.Pages.Models.EventCompany> EventCompany { get; set; } = default!;
        public DbSet<ManagementEvent.Pages.Models.EventType> EventType { get; set; } = default!;
    }
}
