using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor.Data;
using Razor.Model;

namespace Razor.Pages.Movies;

public class DetailsModel(MovieContext movieContext, Order order) : PageModel
{
    public Shedule? Shedule { get; set; }
    public async Task OnGetAsync(int id)
    {
        Shedule = await movieContext.Shedules.Include(shedules => shedules.Movie).FirstAsync(shedules => shedules.Id == id);
    }

    public async Task OnPostAddTicket(int id, int i)
    {
        Shedule = await movieContext.Shedules.Include(shedules => shedules.Movie).FirstAsync(shedules => shedules.Id == id);

        var selectedShedule = await movieContext.Shedules.Where(x => x.Id == id).FirstAsync();
        order.ResultCost += selectedShedule.Cost;
        order.Shedules.Add(selectedShedule);
    }

    public object Test()
    {
        return 1;
    }
}