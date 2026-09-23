using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Models;

/// <summary>
/// Represents a river and the countries through which it flows.
/// </summary>
public partial class River
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string RiverName { get; set; } = null!;

    public int Length { get; set; }

    public int DrainageArea { get; set; }

    public int AverageDischarge { get; set; }

    [StringLength(50)]
    public string Outflow { get; set; } = null!;

    /// <summary>Countries associated with this river.</summary>
    [ForeignKey("RiverId")]
    [InverseProperty("Rivers")]
    public virtual ICollection<Country> CountryCodes { get; set; } = new List<Country>();
}