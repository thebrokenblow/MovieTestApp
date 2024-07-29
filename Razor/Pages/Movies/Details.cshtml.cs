using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;

namespace Razor.Pages.Movies;

public class DetailsModel : PageModel
{
    public Movie? Movie { get; set; }
    public void OnGet(int id)
    {
        Movie = MovieStorage.Movies.Find(x => x.Id == id);
    }
}