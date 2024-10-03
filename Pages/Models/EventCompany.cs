using System;
using System.Collections.Generic;
namespace ManagementEvent.Pages.Models
{
    public class EventCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PositionName { get; set; }  // Position/role of the company in the event
        public decimal MinBudget { get; set; } // Minimum budget for the event
        public decimal MaxBudget { get; set; } // Maximum budget for the event
        public DateTime? EventStartDate { get; set; } // Nullable start date of the event
        public int EventTypeId { get; set; }  // One EventCompany is associated with one EventType
        public EventType EventType { get; set; }
        public List<EventAttendee> EventAttendees { get; set; }
    }
}
