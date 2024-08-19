using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;
using System.ComponentModel.DataAnnotations;

namespace Razor.Pages.Movies;

public class IndexModel(MovieContext movieContext, FormattedSchedule formattedSchedule) : PageModel
{
    public Dictionary<Movie, List<Schedule>>? SchedulesByMovie { get; set; }
    public string? MinDateMovie { get; set; }
    public string? MaxDateMovie { get; set; }
    public string? SelectedDateMovie { get; set; }

    private const string FormatDate = "yyyy-MM-dd";
    private const string FormatFilteredDate = "{0:yyyy-MM-ddTHH:mm}";

    public async Task OnGet()
    {
        SchedulesByMovie = await movieContext.Schedules
            .Include(schedule => schedule.Movie)
            .Where(schedule => schedule.StartFilm.Date == DateTime.Now.Date)
            .GroupBy(schedule => schedule.Movie)
            .ToDictionaryAsync(group => group.Key, group => group.ToList());

        formattedSchedule.SchedulesByMovie = SchedulesByMovie;

        var maxDateMovie = await movieContext.Schedules.MaxAsync(movie => movie.StartFilm);

        SelectedDateMovie = DateTime.Now.ToString(FormatDate);
        MinDateMovie = DateTime.Now.ToString(FormatDate);
        MaxDateMovie = maxDateMovie.ToString(FormatDate);

        ViewData["Title"] = "Фильмы для показа";
    }

    [BindProperty(SupportsGet = true)]
    public string? SearchTitleMovie { get; set; }

    [BindProperty(SupportsGet = true), DisplayFormat(DataFormatString = FormatFilteredDate, ApplyFormatInEditMode = true)]
    public DateTime? SearchDateMovie { get; set; }

    public async Task OnPostAsync()
    {
        IEnumerable<Schedule>? filteredSchedule = null;

        if (SearchDateMovie is not null)
        {
            filteredSchedule = movieContext.Schedules.Include(schedule => schedule.Movie)
                .Where(schedule =>
                    schedule.StartFilm.Day == SearchDateMovie.Value.Day &&
                    schedule.StartFilm.Month == SearchDateMovie.Value.Month);
        }

        if (SearchTitleMovie is not null)
        {
            if (filteredSchedule is not null)
            {
                filteredSchedule = filteredSchedule.Where(schedule => schedule.Movie.Title.Contains(SearchTitleMovie));
            }
            else
            {
                filteredSchedule = movieContext.Schedules.Where(schedule => schedule.Movie.Title.Contains(SearchTitleMovie));
            }
        }

        if (filteredSchedule is null)
        {
            formattedSchedule.SchedulesByMovie = SchedulesByMovie;
        }
        else
        {
            formattedSchedule.SchedulesByMovie = filteredSchedule
                .GroupBy(schedule => schedule.Movie)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        var maxDateMovie = await movieContext.Schedules.MaxAsync(movie => movie.StartFilm);

        MinDateMovie = DateTime.Now.ToString(FormatDate);
        MaxDateMovie = maxDateMovie.ToString(FormatDate);
    }
}