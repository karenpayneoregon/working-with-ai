﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SetupEntityFrameworkCoreApp.Models;

public partial class PhoneType
{
    public int PhoneTypeIdenitfier { get; set; }

    public string PhoneTypeDescription { get; set; }

    public virtual ICollection<ContactDevices> ContactDevices { get; set; } = new List<ContactDevices>();
}