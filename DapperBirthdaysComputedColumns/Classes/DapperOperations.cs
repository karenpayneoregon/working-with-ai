﻿using System.Data;
using ConsoleConfigurationLibrary.Classes;
using Dapper;
using DapperBirthdaysComputedColumns.Models;
using kp.Dapper.Handlers;
using Microsoft.Data.SqlClient;

namespace DapperBirthdaysComputedColumns.Classes;
internal class DapperOperations
{
    private IDbConnection _cn;

    /// <summary>
    /// Initializes a new instance of the <see cref="DapperOperations"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor configures the database connection using the main connection string 
    /// from AppConnections.Instance.MainConnection. Additionally, it registers 
    /// a custom type handler, <see cref="SqlDateOnlyTypeHandler"/>, to handle <see cref="DateOnly"/> 
    /// types effectively.
    /// </remarks>
    public DapperOperations()
    {
        // Initialize the connection with a short timeout for demonstration purposes
        var builder = new SqlConnectionStringBuilder(AppConnections.Instance.MainConnection)
        {
            ConnectTimeout = 2
        };
        _cn = new SqlConnection(builder.ConnectionString);
        SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
    }

    /// <summary>
    /// Retrieves a list of birthdays from the database asynchronously.
    /// </summary>
    /// <remarks>
    /// This method executes a SQL query defined in <see cref="SqlStatements.GetBirthdays"/> 
    /// to fetch data from the database and maps the results to a list of <see cref="BirthDays"/> objects.
    /// The data includes a computed column, <see cref="BirthDays.YearsOld"/>, which represents the age of the individual.
    /// </remarks>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of <see cref="BirthDays"/> objects.
    /// </returns>
    /// <exception cref="SqlException">
    /// Thrown when there is an issue executing the SQL query.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the database connection is not properly initialized.
    /// </exception>
    public async Task<List<BirthDays>> GetBirthdaysAsync()
    {
        return (await _cn.QueryAsync<BirthDays>(SqlStatements.GetBirthdays)).AsList();
    }

}
