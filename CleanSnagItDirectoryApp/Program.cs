using CleanSnagItDirectoryApp.Classes;

namespace CleanSnagItDirectoryApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var fileOps = new FileOperations();
        fileOps.DeleteSnagit(@"C:\Users\paynek\Documents\Snagit");
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}