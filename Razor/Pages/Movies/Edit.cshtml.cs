using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class EditModel(MovieContext movieContext) : PageModel
{
    [BindProperty]
    public Movie? Movie { get; set; }

    public async Task OnGetAsync(int id)
    {
        Movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
    }

    public async Task<IActionResult> OnPostUpdate(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var updatedMovie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
        updatedMovie.Title = Movie.Title;
        updatedMovie.URL = Movie.URL;
        updatedMovie.Description = Movie.Description;
        await movieContext.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
