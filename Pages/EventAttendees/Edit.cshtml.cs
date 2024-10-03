using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementEvent.Data;
using ManagementEvent.Pages.Models;

namespace ManagementEvent.Pages.EventAttendees
{
    public class EditModel : PageModel
    {
        private readonly ManagementEvent.Data.ManagementEventContext _context;

        public EditModel(ManagementEvent.Data.ManagementEventContext context)
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

            var eventattendee =  await _context.EventAttendee.FirstOrDefaultAsync(m => m.Id == id);
            if (eventattendee == null)
            {
                return NotFound();
            }
            EventAttendee = eventattendee;
           ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id");
           ViewData["EventTypeId"] = new SelectList(_context.Set<EventType>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventAttendee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventAttendeeExists(EventAttendee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventAttendeeExists(int id)
        {
            return _context.EventAttendee.Any(e => e.Id == id);
        }
    }
}
