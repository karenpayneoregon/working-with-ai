using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AiWebApplication1.Pages;
public class IndexModel : PageModel
{
  

    public IndexModel()
    {
        Log.Information("Index model initialized.");  
    }

    public void OnGet()
    {

        Log.Information("OnGet method called.");
    }
}
