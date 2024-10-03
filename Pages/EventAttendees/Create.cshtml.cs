﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagementEvent.Data;
using ManagementEvent.Pages.Models;

namespace ManagementEvent.Pages.EventAttendees
{
    public class CreateModel : PageModel
    {
        private readonly ManagementEvent.Data.ManagementEventContext _context;

        public CreateModel(ManagementEvent.Data.ManagementEventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id");
        ViewData["EventTypeId"] = new SelectList(_context.Set<EventType>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public EventAttendee EventAttendee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EventAttendee.Add(EventAttendee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
