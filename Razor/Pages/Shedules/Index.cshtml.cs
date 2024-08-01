using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Shedules
{
    public class IndexModel : PageModel
    {
        private readonly Razor.Data.MovieContext _context;

        public IndexModel(Razor.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Shedule> Shedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Shedule = await _context.Shedules.ToListAsync();
        }
    }
}
