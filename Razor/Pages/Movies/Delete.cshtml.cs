using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class DeleteModel(MovieContext movieContext) : PageModel
{
    public Movie? Movie { get; set; }
    public async Task OnGetAsync(int id)
    {
        Movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {

        var movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
        movieContext.Movies.Remove(movie);
        await movieContext.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}