using Serilog;
using Serilog.Events;

namespace AiWebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        // Configure Serilog
        var logPath = Path.Combine(AppContext.BaseDirectory, "Log", 
            DateTime.UtcNow.ToString("yyyy-MM-dd"), "log.txt");

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .WriteTo.File(
                logPath,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                shared: true
            )
            .CreateLogger();

        var builder = WebApplication.CreateBuilder(args);

        // Replace default logging with Serilog
        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapRazorPages().WithStaticAssets();

        app.Run();
    }
}
