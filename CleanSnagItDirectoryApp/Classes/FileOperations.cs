namespace CleanSnagItDirectoryApp.Classes;
public class FileOperations
{
    /// <summary>
    /// Deletes all `.snagx` files in the specified directory that start with the current year.
    /// </summary>
    /// <param name="directoryPath">
    /// The path of the directory to search for `.snagx` files.
    /// </param>
    /// <remarks>
    /// If the directory does not exist, a message is logged, and no action is taken. 
    /// For each file matching the criteria, an attempt is made to delete it. 
    /// Any errors encountered during deletion are logged.
    /// </remarks>
    /// <exception cref="IOException">
    /// Thrown if an I/O error occurs during file deletion.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">
    /// Thrown if the application lacks the necessary permissions to delete files.
    /// </exception>
    public void DeleteSnagit(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"Directory does not exist: {directoryPath}");
            return;
        }

        string currentYear = DateTime.Now.Year.ToString();
        string[] files = Directory.GetFiles(directoryPath, $"{currentYear}*.snagx");

        foreach (var file in files)
        {
            try
            {
                File.Delete(file);
                Console.WriteLine($"Deleted: {file}");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[fuchsia]Failed to delete[/] {file}: {ex.Message}");
            }
        }

        AnsiConsole.MarkupLine($"[green]Deletion process completed.[/] {files.Length} file(s) processed.");
    }
}