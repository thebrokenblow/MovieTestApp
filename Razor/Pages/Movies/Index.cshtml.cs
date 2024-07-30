using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class IndexModel(MovieContext movieContext) : PageModel
{
    public IEnumerable<Movie> Movies { get; set; } = movieContext.Movies;
    public DateTime MaxDateMovie { get; set; }
    public void OnGet()
    {
        MaxDateMovie = (from row in movieContext.Shedules
        group row by true into r
        select new
        {
            max = r.Max(z => z.StartFilm)
        }).First().max;

        ViewData["Title"] = "Фильмы для показа";
    }

    [BindProperty]
    public string? SearchTitleMovie { get; set; }

    public async Task OnPostAsync()
    {
        if (SearchTitleMovie is null)
        {
            return;
        }

        Movies = await movieContext.Movies.Where(movie => movie.Title.Contains(SearchTitleMovie)).ToListAsync();
    }
}