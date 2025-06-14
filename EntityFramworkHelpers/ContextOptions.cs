using System.Diagnostics;
using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkHelpers;
public class ContextOptions
{
    /// <summary>
    /// Configures and returns a <see cref="DbContextOptionsBuilder{T}"/> for development environments.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="DbContext"/> for which the options are being configured.
    /// </typeparam>
    /// <param name="connectionString">
    /// The connection string used to connect to the database.
    /// </param>
    /// <returns>
    /// A configured <see cref="DbContextOptionsBuilder{T}"/> instance for the specified <see cref="DbContext"/> type.
    /// </returns>
    /// <remarks>
    /// This method configures the <see cref="DbContextOptionsBuilder{T}"/> to use SQL Server as the database provider,
    /// enables sensitive data logging, and logs database commands to the debug output with a log level of <see cref="LogLevel.Information"/>.
    /// </remarks>
    public static DbContextOptionsBuilder<T> Development<T>(string connectionString) where T : DbContext
    {   

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlServer(connectionString)
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
            .EnableSensitiveDataLogging();

        return options;

    }
    /// <summary>
    /// Configures and returns a <see cref="DbContextOptionsBuilder{T}"/> for production environments.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the <see cref="DbContext"/> for which the options are being configured.
    /// </typeparam>
    /// <param name="connectionString">
    /// The connection string used to connect to the database.
    /// </param>
    /// <returns>
    /// A configured <see cref="DbContextOptionsBuilder{T}"/> instance for the specified <see cref="DbContext"/> type.
    /// </returns>
    /// <remarks>
    /// This method configures the <see cref="DbContextOptionsBuilder{T}"/> to use SQL Server as the database provider
    /// and logs database commands to a file using <see cref="DbContextToFileLogger"/> with a log level of <see cref="LogLevel.Information"/>.
    /// </remarks>
    public static DbContextOptionsBuilder<T> Production<T>(string connectionString) where T : DbContext
    {

        var options = new DbContextOptionsBuilder<T>()
            .UseSqlServer(connectionString)
            .LogTo(new DbContextToFileLogger().Log, [DbLoggerCategory.Database.Command.Name], 
                LogLevel.Information);

        return options;

    }
}