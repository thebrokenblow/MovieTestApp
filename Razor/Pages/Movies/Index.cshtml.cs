using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;


namespace Razor.Pages.Movies;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Фильмы для показа";
    }
}