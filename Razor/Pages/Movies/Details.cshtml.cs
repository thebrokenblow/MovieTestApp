using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class DetailsModel(MovieContext movieContext) : PageModel
{
    public Movie? Movie { get; set; }
    public async Task OnGetAsync(int id)
    {
        Movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
    }
}