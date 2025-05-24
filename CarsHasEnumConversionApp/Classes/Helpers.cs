using Microsoft.Extensions.Configuration;

namespace CarsHasEnumConversionApp.Classes;
public class Helpers
{
    /// <summary>
    /// Retrieves the application configuration from a specified JSON file.
    /// </summary>
    /// <returns>An <see cref="IConfigurationRoot"/> object representing the application configuration.</returns>
    /// <remarks>
    /// Added by Karen, after specifying the type Copilot did the rest.
    /// </remarks>
    public static IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }

    /// <summary>
    /// Retrieves the connection string for the application's default database.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the connection string for the "DefaultConnection" key in the configuration.</returns>
    /// <remarks>
    /// This method depends on the configuration provided by the <see cref="GetConfiguration"/> method.
    /// Ensure that the "DefaultConnection" key is present in the appsettings.json file.
    ///
    /// Karen added this method to retrieve the connection string from the configuration file, Copilot suggested the rest.
    /// 
    /// </remarks>
    public static string GetConnectionString()
    {
        return GetConfiguration().GetConnectionString("DefaultConnection");
    }
}
