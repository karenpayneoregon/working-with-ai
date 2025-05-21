using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace AiWebApplication1.Pages;

/// <summary>
/// Karen ask Copilot to change from conventional logging to Serilog.
///
/// - Code for OnGet was placed under OnGet then Copilot fix it with the press of TAB.
/// </summary>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    // Replace ILogger with Serilog's static Log class, so remove this field
    // private readonly ILogger<ErrorModel> _logger;

    // Remove logger from constructor
    public ErrorModel()
    {
    }

    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        Serilog.Log.Information("Error page accessed. RequestId: {RequestId}", RequestId);
    }
}

