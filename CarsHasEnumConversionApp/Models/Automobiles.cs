﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CarsHasEnumConversionApp.Models;

public partial class Automobiles
{
    public int Id { get; set; }

    public string CarName { get; set; }

    public Manufacturer Manufacturer { get; set; }
}