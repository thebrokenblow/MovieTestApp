using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Razor.Pages.Movies;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "������ ��� ������";
    }
}