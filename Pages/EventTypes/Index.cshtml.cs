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
    public class IndexModel : PageModel
    {
        private readonly ManagementEvent.Data.ManagementEventContext _context;

        public IndexModel(ManagementEvent.Data.ManagementEventContext context)
        {
            _context = context;
        }

        public IList<EventType> EventType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EventType = await _context.EventType.ToListAsync();
        }
    }
}
