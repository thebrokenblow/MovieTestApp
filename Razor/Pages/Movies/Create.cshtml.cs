using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;

namespace Razor.Pages.Movies;

public class CreateModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Добавление фильма";
    }

    [BindProperty]
    public Movie? Movie { get; set; }

    public IActionResult OnPost()
    {
        if (Movie is not null && ModelState.IsValid)
        {
            MovieStorage.Movies.Add(Movie);
            return RedirectToPage("./Index");
        }

        return Page();
    }
}