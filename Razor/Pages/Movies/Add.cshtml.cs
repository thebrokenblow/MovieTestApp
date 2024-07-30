using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class AddModel(MovieContext movieContext) : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Добавение фильма";
    }

    [BindProperty]
    public Movie? Movie { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        if (Movie is null || !ModelState.IsValid)
        {
            return Page();
        }

        await movieContext.Movies.AddAsync(Movie);
        await movieContext.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
