using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementEvent.Data;
using ManagementEvent.Pages.Models;

namespace ManagementEvent.Pages.EventAttendees
{
    public class DeleteModel : PageModel
    {
        private readonly ManagementEvent.Data.ManagementEventContext _context;

        public DeleteModel(ManagementEvent.Data.ManagementEventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventAttendee EventAttendee { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventattendee = await _context.EventAttendee.FindAsync(id);
            if (eventattendee != null)
            {
                EventAttendee = eventattendee;
                _context.EventAttendee.Remove(EventAttendee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
