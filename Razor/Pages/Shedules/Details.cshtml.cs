﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Razor.Data.MovieContext _context;

        public DetailsModel(Razor.Data.MovieContext context)
        {
            _context = context;
        }

        public Shedule Shedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shedule = await _context.Shedules.FirstOrDefaultAsync(m => m.Id == id);
            if (shedule == null)
            {
                return NotFound();
            }
            else
            {
                Shedule = shedule;
            }
            return Page();
        }
    }
}
