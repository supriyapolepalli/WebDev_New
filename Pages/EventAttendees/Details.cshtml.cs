using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementEvent.Data;
using ManagementEvent.Pages.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManagementEvent.Pages.EventAttendees
{
    public class DetailsModel : PageModel
    {
        private readonly ManagementEvent.Data.ManagementEventContext _context;

        public DetailsModel(ManagementEvent.Data.ManagementEventContext context)
        {
            _context = context;
        }

        public EventAttendee EventAttendee { get; set; } = default!;
        public List<EventAttendee> Attendees { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventattendee = await _context.EventAttendee.FirstOrDefaultAsync(m => m.Id == id);
            if (eventattendee == null)
            {
                return NotFound();
            }
            else
            {
                EventAttendee = eventattendee;
            }
            return Page();

        }


    }
  
}
