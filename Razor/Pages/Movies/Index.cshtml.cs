using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Razor.Pages.Movies;

public class IndexModel(MovieContext movieContext) : PageModel
{
    public IEnumerable<Shedule>? Shedules { get; set; }

    public string? MinDateMovie { get; set; }
    public string? MaxDateMovie { get; set; }
    public string? SelectedDateMovie { get; set; }

    //Так как при получении месяца или дня меньше 10 возвращаемый формат будет
    //в диапазоне от 1 до 9, нам нужен формат 01-09.
    private const int tenthNumber = 10;

    public async Task OnGet()
    {
        Shedules = movieContext.Shedules
            .Include(shedule => shedule.Movie)
            .Where(shedule => shedule.StartFilm.Date == DateTime.Now.Date);

        var maxDateMovie = await movieContext.Shedules.MaxAsync(movie => movie.StartFilm);

        SelectedDateMovie = ChangeFormatDate(DateTime.Now);
        MinDateMovie = ChangeFormatDate(DateTime.Now);
        MaxDateMovie = ChangeFormatDate(maxDateMovie);

        ViewData["Title"] = "Фильмы для показа";
    }

    [BindProperty]
    public string? SearchTitleMovie { get; set; }
    [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
    public DateTime? SearchDateMovie { get; set; }

    public async Task OnPostAsync()
    {
        IEnumerable<Shedule>? filteredShedules = null;

        if (SearchDateMovie is not null)
        {
            SelectedDateMovie = ChangeFormatDate(SearchDateMovie.Value);

            filteredShedules = movieContext.Shedules.Include(shedule => shedule.Movie)
                .Where(shedule =>
                    shedule.StartFilm.Day == SearchDateMovie.Value.Day &&
                    shedule.StartFilm.Month == SearchDateMovie.Value.Month);
        }

        if (SearchTitleMovie is not null)
        {
            if (filteredShedules is not null)
            {
                filteredShedules = filteredShedules.Where(shedule => shedule.Movie.Title.Contains(SearchTitleMovie));
            }
            else
            {
                filteredShedules = movieContext.Shedules.Where(shedule => shedule.Movie.Title.Contains(SearchTitleMovie));
            }
        }

        Shedules = filteredShedules;
       
        var maxDateMovie = await movieContext.Shedules.MaxAsync(movie => movie.StartFilm);

        MinDateMovie = ChangeFormatDate(DateTime.Now);
        MaxDateMovie = ChangeFormatDate(maxDateMovie);
    }

    public string FormateTime(int time)
    {
        if (time == 0)
        {
            return "00";
        }

        return time.ToString();
    }

    private static string ChangeFormatDate(DateTime dateTime)
    {
        var strBuilderDate = new StringBuilder();
        strBuilderDate.Append($"{dateTime.Year}-");

        if (dateTime.Month < tenthNumber)
        {
            strBuilderDate.Append($"0{dateTime.Month}-");
        }
        else
        {
            strBuilderDate.Append($"dateTime.Month-");
        }

        if (dateTime.Day < tenthNumber)
        {
            strBuilderDate.Append($"0{dateTime.Day}");
        }
        else
        {
            strBuilderDate.Append($"{dateTime.Day}");
        }

        return strBuilderDate.ToString();
    }
}