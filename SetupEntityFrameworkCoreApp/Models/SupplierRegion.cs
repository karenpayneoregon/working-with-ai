﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SetupEntityFrameworkCoreApp.Models;

public partial class SupplierRegion
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Suppliers> Suppliers { get; set; } = new List<Suppliers>();
}