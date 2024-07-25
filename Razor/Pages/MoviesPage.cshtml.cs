using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie;

namespace Razor.Pages;

public class MoviesPageModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Фильмы для показа";
    }


    [BindProperty]
    public MyMovie? MyMovie { get; set; }

    public IActionResult OnPost()
    {
        if (MyMovie is not null && ModelState.IsValid)
        {
            MovieStorage.myMovies.Add(MyMovie);
            return RedirectToPage("/MoviesPage");
        }
        
        return Page();
    }
}