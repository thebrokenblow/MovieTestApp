﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.HallsCinema
{
    public class CreateModel : PageModel
    {
        private readonly Razor.Data.MovieContext _context;

        public CreateModel(Razor.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HallCinema HallCinema { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HallCinemas.Add(HallCinema);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
