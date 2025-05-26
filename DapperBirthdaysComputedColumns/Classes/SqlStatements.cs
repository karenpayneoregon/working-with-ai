namespace DapperBirthdaysComputedColumns.Classes;
internal class SqlStatements
{
    public static string GetBirthdays =>
        """
        SELECT Id
            ,FirstName
            ,LastName
            ,BirthDate
            ,YearsOld
        FROM dbo.BirthDays
        ORDER BY YearsOld DESC
        """;
}
