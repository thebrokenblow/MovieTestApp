using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class DetailsModel(MovieContext movieContext, Ticket ticket) : PageModel
{
    public Schedule? Schedule { get; set; }
    public async Task OnGetAsync(int id)
    {
        Schedule = await movieContext.Schedules
            .Include(schedule => schedule.HallCinema)
            .Include(schedule => schedule.Movie)
            .FirstAsync(schedule => schedule.Id == id);

        ticket.SelectedSchedule = Schedule;
    }

    public async Task OnGetDelete(int i)
    {
        
    }
}