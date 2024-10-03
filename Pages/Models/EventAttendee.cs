using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ManagementEvent.Pages.Models
{
    public class EventAttendee
    {
        public int Id  { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Target Budget")]
        public decimal TargetBudget { get; set; } // Additional Property
        [DisplayName("Optional Arrival Date")]
        [DataType(DataType.Date)]
        public DateTime? OptionalArrivalDate { get; set; } // Nullable Additional Property
        [DisplayName("Event ID")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100)]
        public int EventId  { get; set; }  // Relationship: One EventAttendee is associated with one Event
        public Event Event { get; set; }
        [DisplayName("Event Type")]// One EventAttendee is associated with one EventType
        public EventType EventType { get; set; }
    
}
}
