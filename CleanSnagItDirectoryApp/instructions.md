# ChatGPT instructions

# Instructions

**Prompt**

C# create a class named `FileOperations` with a method named `DeleteSnagit` which deletes files starting  with the current year in the file name with .snagx extenstion

**Response**

Here's a `FileOperations` class in C# that includes a `DeleteSnagit` method. This method deletes files that begin with the current year and have a .snagx extension.

```csharp
using System;
using System.IO;

public class FileOperations
{
    /// <summary>
    /// Deletes all .snagx files in the specified directory that start with the current year.
    /// </summary>
    /// <param name="directoryPath">The path of the directory to search.</param>
    public void DeleteSnagit(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"Directory does not exist: {directoryPath}");
            return;
        }

        string currentYear = DateTime.Now.Year.ToString();
        string[] files = Directory.GetFiles(directoryPath, $"{currentYear}*.snagx");

        foreach (string file in files)
        {
            try
            {
                File.Delete(file);
                Console.WriteLine($"Deleted: {file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {file}: {ex.Message}");
            }
        }

        Console.WriteLine($"Deletion process completed. {files.Length} file(s) processed.");
    }
}

```

**Notes**

- This method checks if the directory exists.
- It builds a wildcard pattern using the current year and .snagx extension.
- Each matching file is attempted to be deleted.
- Errors are logged to the console instead of halting the process.

**Usage:**

```csharp
var fileOps = new FileOperations();
fileOps.DeleteSnagit(@"C:\Users\Karen\Documents\Snagit");
```

Let me know if you want it to support subdirectories or log to a file instead of the console.

> **Note**
> I did not indicate the folder name and ChatGPT got it right.

## Modifications

- Rewrote documentation use JetBrains [AI Assistant](https://www.jetbrains.com/ai/)
- Added [Spectre.Console](https://www.nuget.org/packages/Spectre.Console/0.50.1-preview.0.5) for better console output