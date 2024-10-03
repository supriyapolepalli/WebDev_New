using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementEvent.Data;
using ManagementEvent.Pages.Models;

namespace ManagementEvent.Pages.EventTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ManagementEvent.Data.ManagementEventContext _context;

        public DeleteModel(ManagementEvent.Data.ManagementEventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventType EventType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventtype = await _context.EventType.FirstOrDefaultAsync(m => m.Id == id);

            if (eventtype == null)
            {
                return NotFound();
            }
            else
            {
                EventType = eventtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventtype = await _context.EventType.FindAsync(id);
            if (eventtype != null)
            {
                EventType = eventtype;
                _context.EventType.Remove(EventType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
