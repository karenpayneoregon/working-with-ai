﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SetupEntityFrameworkCoreApp.Models;

public partial class Suppliers
{
    public int SupplierID { get; set; }

    public string CompanyName { get; set; }

    public string ContactName { get; set; }

    public string ContactTitle { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public int RegionId { get; set; }

    public string PostalCode { get; set; }

    public int? CountryIdentifier { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string HomePage { get; set; }

    public virtual Countries CountryIdentifierNavigation { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();

    public virtual SupplierRegion RegionNavigation { get; set; }
}