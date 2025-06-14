using SetupEntityFrameworkCoreApp.Classes;
using SetupEntityFrameworkCoreApp.Models;

namespace SetupEntityFrameworkCoreApp;

using Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        var connectionString = builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"The connection string {nameof(ConnectionStrings.DefaultConnection)} is not configured.");
        }

        builder.Services.AddDbContextPool<Context>(_ => { });
        var options = ContextOptions.Production(connectionString).Options;
        builder.Services.AddSingleton(options);

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
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
