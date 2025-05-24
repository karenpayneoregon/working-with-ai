# About

Prompts used.<!--TOC-->
  - [First prompt to Copilot](#first-prompt-to-copilot)
  - [Second prompt to Copilot](#second-prompt-to-copilot)
  - [Third prompt to Copilot](#third-prompt-to-copilot)
  - [Summary](#summary)
  - [See also](#see-also)
<!--/TOC-->

## First prompt to Copilot	

- add connection string to appsettings.json and alter code to read from appsettings.json

Tried the above two time but Copilot did not get it right. After the failure the following was recommended.

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
}
```

Had to manually add the connection string to the appsettings.json file.
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarsDatabase;Integrated Security=True;Encrypt=False"
  }
}
```

## Second prompt to Copilot

- For Automobiles model set up on property HasConversion to enum Manufacturer

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Automobiles>(entity =>
    {
        entity.Property(e => e.Manufacturer)
            .HasConversion<int>();
    });

    OnModelCreatingPartial(modelBuilder);
}
```

The above was added but I expected Copilot to alter `Automobiles.Manufacturer` from `int` to `Manufacturer` but did not so I had too make the change.

## Third prompt to Copilot

Alter the automobiles variable to use a Where for Manufacturer.Mazda

Response was
```csharp
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
```

- I added 
  - `await` code.
  - `Id` to the output

## Summary

Copilot did a great job other than missing changing Manufacturer property in Automobiles model which for an experienced developer is an easy fix while for a developer who has never worked with HasConversion may very well get stuck.

## See also

- [Value Conversions](https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations)
- [Microsoft.EntityFrameworkCore.Storage.ValueConversion](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.storage.valueconversion?view=efcore-5.0)
- My [repository](https://github.com/karenpayneoregon/ef-core-enums) for HasConversion which in the code sample for `Wine` uses a `T4 template` to generate the enum from the database.