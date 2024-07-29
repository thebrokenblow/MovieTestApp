using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;

namespace Razor.Pages.Movies;

public class CreateModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "���������� ������";
    }

    [BindProperty]
    public Movie? Movie { get; set; }

    public IActionResult OnPost()
    {
        var lastMovie = MovieStorage.Movies.Last();
        Movie.Id = lastMovie.Id;
        Movie.Id++;

        if (Movie is not null && ModelState.IsValid)
        {
            MovieStorage.Movies.Add(Movie);
            return RedirectToPage("./Index");
        }

        return Page();
    }
}