using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SetupEntityFrameworkCoreApp.Data;
using SetupEntityFrameworkCoreApp.Models;

namespace SetupEntityFrameworkCoreApp.Pages
{
    public class ViewModel : PageModel
    {
        private readonly SetupEntityFrameworkCoreApp.Data.Context _context;

        public ViewModel(SetupEntityFrameworkCoreApp.Data.Context context)
        {
            _context = context;
        }

        public IList<Customers> Customers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers
                .Include(c => c.Contact)
                .Include(c => c.ContactTypeIdentifierNavigation)
                .Include(c => c.CountryIdentifierNavigation).ToListAsync();
        }
    }
}
