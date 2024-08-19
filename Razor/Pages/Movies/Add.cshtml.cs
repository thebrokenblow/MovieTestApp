using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Data;
using Razor.Model;
using Razor.Services;
using Razor.ViewModel;
using System.Net;

namespace Razor.Pages.Movies;

public class AddModel(MovieContext movieContext, IPhotoService photoService) : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Добавление фильма";
    }

    [BindProperty]
    public MovieViewModel? MovieViewModel { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        if (MovieViewModel is null || !ModelState.IsValid)
        {
            return Page();
        }
        var result = await photoService.AddPhotoAsync(MovieViewModel.URL);
        var movie = new Movie()
        {
            Title = MovieViewModel.Title,
            Description = MovieViewModel.Description,
            Duration = MovieViewModel.Duration,
            URL = result.Url.ToString(),
        };
        await movieContext.Movies.AddAsync(movie);
        await movieContext.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
