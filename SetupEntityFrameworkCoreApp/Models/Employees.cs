﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SetupEntityFrameworkCoreApp.Models;

public partial class Employees
{
    public int EmployeeID { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public int? ContactTypeIdentifier { get; set; }

    public string TitleOfCourtesy { get; set; }

    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public string PostalCode { get; set; }

    public int? CountryIdentifier { get; set; }

    public string HomePhone { get; set; }

    public string Extension { get; set; }

    public string Notes { get; set; }

    public int? ReportsTo { get; set; }

    public int? ReportsToNavigationEmployeeID { get; set; }

    public virtual ContactType ContactTypeIdentifierNavigation { get; set; }

    public virtual Countries CountryIdentifierNavigation { get; set; }

    public virtual ICollection<Employees> InverseReportsToNavigationEmployee { get; set; } = new List<Employees>();

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    public virtual Employees ReportsToNavigationEmployee { get; set; }

    public virtual ICollection<Territories> Territory { get; set; } = new List<Territories>();
}