# About


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