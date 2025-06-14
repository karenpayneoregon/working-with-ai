# About

Provides two methods for setting up options for a DbContext object

## Example Usage

:diamonds: Add this project to your project as a dependency, then use the following code to set up your DbContext options:

Program.cs in an ASP.NET Core application:

```csharp
var connectionString = builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException($"The connection string {nameof(ConnectionStrings.DefaultConnection)} is not configured.");
}

builder.Services.AddDbContextPool<Context>(_ => { });

var options = ContextOptions.Production<Context>(connectionString);

builder.Services.AddSingleton(options.Options);
```
:diamonds: Include the following model for the above connection string:

```csharp
public class ConnectionStrings
{
    public string DefaultConnection { get; set; }
}
```

:diamonds: Sample application settings.json:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDatabase;User Id=myuser;Password=mypassword;"
  }
}
```