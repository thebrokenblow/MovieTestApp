using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Главная Страница кинотеатра";
    }
}