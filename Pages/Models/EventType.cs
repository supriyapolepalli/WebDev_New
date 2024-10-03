using System;
using System.Collections.Generic;
namespace ManagementEvent.Pages.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name  { get; set; }  // e.g., Wedding, Concert, Conference
        public List<EventAttendee>  EventAttendees { get; set; }
        public List<EventCompany>  EventCompanies { get; set; }
    }
}
