using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;
using Razor.Services;
using Razor.ViewModel;

namespace Razor.Pages.Movies;

public class EditModel(MovieContext movieContext, IPhotoService photoService) : PageModel
{
    [BindProperty]
    public MovieViewModel? MovieViewModel { get; set; }

    public async Task OnGetAsync(int id)
    {
        var movie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);
        MovieViewModel = new MovieViewModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            URL = null,
            Duration = movie.Duration,
        };
    }

    public async Task<IActionResult> OnPostUpdate(int id)
    {
        if (!ModelState.IsValid || MovieViewModel is null)
        {
            return Page();
        }

        if (MovieViewModel.URL is null)
        {
            return Page();
        }

        var updatedMovie = await movieContext.Movies.FirstAsync(movie => movie.Id == id);

        var photoResult = await photoService.AddPhotoAsync(MovieViewModel.URL);

        if (!string.IsNullOrEmpty(updatedMovie.URL))
        {
            _ = photoService.DeletePhotoAsync(updatedMovie.URL);
        }

        if (photoResult.Error != null)
        {
            ModelState.AddModelError("Image", "Photo upload failed");
            return Page();
        }
        updatedMovie.Title = MovieViewModel.Title;
        updatedMovie.URL = MovieViewModel.URL.ToString();
        updatedMovie.Description = MovieViewModel.Description;
        await movieContext.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
