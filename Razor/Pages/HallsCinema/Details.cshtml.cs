using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.HallsCinema
{
    public class DetailsModel : PageModel
    {
        private readonly Razor.Data.MovieContext _context;

        public DetailsModel(Razor.Data.MovieContext context)
        {
            _context = context;
        }

        public HallCinema HallCinema { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallcinema = await _context.HallCinemas.FirstOrDefaultAsync(m => m.NumberHall == id);
            if (hallcinema == null)
            {
                return NotFound();
            }
            else
            {
                HallCinema = hallcinema;
            }
            return Page();
        }
    }
}
