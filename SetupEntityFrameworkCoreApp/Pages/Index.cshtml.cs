using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SetupEntityFrameworkCoreApp.Data;
using SetupEntityFrameworkCoreApp.Models;

namespace SetupEntityFrameworkCoreApp.Pages;
public class IndexModel(Context context) : PageModel
{
    public IList<Customers> Customers { get; set; } = null!;

    public async Task OnGetAsync()
    {
        Customers = await context.Customers
            .Include(c => c.Contact)
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Include(c => c.CountryIdentifierNavigation)
            .ToListAsync();
    }
}
