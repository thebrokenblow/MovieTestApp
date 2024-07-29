using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;

namespace Razor.Pages.Movies;

public class DeleteModel : PageModel
{
    public Movie? Movie { get; set; }
    public void OnGet(int? id)
    {
        Movie = MovieStorage.Movies.First(movie => movie.Id == id);
    }

    public IActionResult OnPostDelete(int id)
    {
        var movie = MovieStorage.Movies.First(movie => movie.Id == id);
        MovieStorage.Movies.Remove(movie);

        return RedirectToPage("./Index");
    }
}