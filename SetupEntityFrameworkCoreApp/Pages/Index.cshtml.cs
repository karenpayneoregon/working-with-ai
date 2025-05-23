using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SetupEntityFrameworkCoreApp.Data;
using SetupEntityFrameworkCoreApp.Models;

namespace SetupEntityFrameworkCoreApp.Pages;
public class IndexModel : PageModel
{
    private readonly SetupEntityFrameworkCoreApp.Data.Context _context;

    public IndexModel(Context context)
    {
       _context = context;
    }
    public IList<Customers> Customers { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Customers = await _context.Customers
            .Include(c => c.Contact)
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Include(c => c.CountryIdentifierNavigation).ToListAsync();
    }
}
