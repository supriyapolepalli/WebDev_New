using System;
using System.Collections.Generic;
namespace ManagementEvent.Pages.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title  { get; set; }  // Event title
        public decimal MinBudget  { get; set; }
        public decimal MaxBudget  { get; set; }
        public DateTime? EventDate { get; set; }  // Nullable event date
        public List<EventAttendee> EventAttendees { get; set; }
    }
}
