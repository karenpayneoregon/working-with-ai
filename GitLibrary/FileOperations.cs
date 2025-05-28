using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
#pragma warning disable CA1822

namespace GitLibrary;

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
            var matcher = new Matcher();
            matcher.AddInclude("**/copilot-instructions.md");

            var result = new List<string>();

            if (!Directory.Exists(rootDirectory))
                return result; // Or throw if this is still critical

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
}
