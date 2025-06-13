using CleanSnagItDirectoryApp.Models;
using Microsoft.Extensions.Configuration;

namespace CleanSnagItDirectoryApp.Classes;
internal class SettingsOperations
{
    /// <summary>
    /// Retrieves the folder path specified in the application settings.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> representing the folder path configured in the application's settings.
    /// </returns>
    /// <remarks>
    /// This method reads the `appsettings.json` file to fetch the folder path defined under the 
    /// <see cref="ApplicationSettings"/> section. Ensure that the `appsettings.json` file exists 
    /// and contains the required configuration.
    /// </remarks>
    public static string GetFolderPath()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        return config.GetSection(nameof(ApplicationSettings))
            .Get<ApplicationSettings>().FolderName;
    }

}
