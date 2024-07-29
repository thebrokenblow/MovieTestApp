using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;

namespace Razor.Pages.Movies;

public class EditModel : PageModel
{
    [BindProperty]
    public Movie Movie { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = MovieStorage.Movies.First(movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        Movie = movie;

        return Page();
    }

    public IActionResult OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var oldMovie = MovieStorage.Movies.First(movie => movie.Id == Movie.Id);
        oldMovie.Title = Movie.Title;
        oldMovie.URL = Movie.URL;
        oldMovie.Description = Movie.Description;
        oldMovie.Cost = Movie.Cost;

        return RedirectToPage("./Index");
    }
}