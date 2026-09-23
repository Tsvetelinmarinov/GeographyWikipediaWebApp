using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Models;

/// <summary>
/// Represents a mountain range, its peaks, and the countries it crosses.
/// </summary>
public partial class Mountain
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string MountainRange { get; set; } = null!;

    /// <summary>Peaks that belong to this mountain range.</summary>
    [InverseProperty("Mountain")]
    public virtual ICollection<Peak> Peaks { get; set; } = new List<Peak>();

    /// <summary>Countries associated with this mountain range.</summary>
    [ForeignKey("MountainId")]
    [InverseProperty("Mountains")]
    public virtual ICollection<Country> CountryCodes { get; set; } = new List<Country>();
}