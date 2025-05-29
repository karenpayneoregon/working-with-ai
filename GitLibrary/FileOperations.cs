using GitLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
#pragma warning disable CA1822

namespace GitLibrary;

/// <summary>
/// Work in progress
/// </summary>
public class FileOperations
{
    /// <summary>
    /// Asynchronously searches for instruction files within the specified root directory.
    /// </summary>
    /// <param name="rootDirectory">
    /// The root directory where the search for instruction files will begin.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of file paths
    /// for the instruction files found within the specified root directory.
    /// </returns>
    public Task<List<string>> FindInstructionFilesAsync(string rootDirectory, CancellationToken cancellationToken) =>
        Task.Run(() =>
        {
            Matcher matcher = new();
            string[] includePatterns = ["**/copilot-instructions.md", "**/.instructions.md"];
            matcher.AddIncludePatterns(includePatterns);
            
            var result = new List<string>();

            if (!Directory.Exists(rootDirectory))
                return result;

            var matchResults = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(rootDirectory)));

            foreach (var file in matchResults.Files)
            {

                if (cancellationToken.IsCancellationRequested)
                {
                    return result;
                }

                var fullPath = Path.Combine(rootDirectory, file.Path);
                result.Add(fullPath);
            }

            return result;

        }, cancellationToken);

    /// <summary>
    /// Retrieves the global settings for the application from appsettings.json.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="GitLibrary.Models.GlobalSetting"/> containing the global configuration settings.
    /// </returns>
    public static GlobalSetting GetGlobalSettings() 
        => ConsoleConfigurationLibrary.Classes.Configuration.JsonRoot().GetSection(nameof(GlobalSetting)).Get<GlobalSetting>()!;


    /// <summary>
    /// Determines whether all required files, as specified in the global settings, are present in the configured directory.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the folder exists and all required files are present; otherwise, <c>false</c>.
    /// </returns>
    public static bool AllRequiredFilesPresent()
    {
        var settings = GetGlobalSettings();

        if (!Directory.Exists(settings.Directory))
            return false;

        List<string> expectedFiles = [settings.CentralInstructionFile, settings.CentralPromptFile];
        return expectedFiles.All(f => File.Exists(Path.Combine(settings.Directory, f)));
    }
}