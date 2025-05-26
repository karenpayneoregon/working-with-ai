namespace DapperBirthdaysComputedColumns.Models;
/// <summary>
/// Represents a model for storing information about birthdays, including details such as 
/// the individual's first name, last name, birth date, and computed age.
/// </summary>
/// <remarks>
/// This class is used in conjunction with Dapper to map database records to objects. 
/// The <see cref="YearsOld"/> property is a computed column in the database that represents 
/// the age of the individual based on their birth date.
/// </remarks>
internal class BirthDays
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public int YearsOld { get; set; }
}
