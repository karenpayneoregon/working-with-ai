using CarsHasEnumConversionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsHasEnumConversionApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await using var context = new Context();
        var automobiles = await  context.Automobiles.Where(x => x.Manufacturer == Manufacturer.Mazda).ToListAsync();

        foreach (var automobile in automobiles)
        {
            Console.WriteLine($"{automobile.Id,-3}{automobile.CarName}, Manufacturer: {automobile.Manufacturer}");
        }

        AnsiConsole.MarkupLine("[yellow]Continue[/]");
        Console.ReadLine();
    }
}