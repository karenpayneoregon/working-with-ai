﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupEntityFrameworkCoreApp.Models
{
    public partial class usp_SelectCatCountryContactTypeResult
    {
        public int CategoryID { get; set; }
        [StringLength(15)]
        public string CategoryName { get; set; }
    }
}
