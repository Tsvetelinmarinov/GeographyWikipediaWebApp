using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.ViewModels;

/// <summary>
/// View-facing representation of a mountain range, its peaks, and associated countries.
/// </summary>
public partial class MountainViewModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string MountainRange { get; set; } = null!;

    /// <summary>Peaks in this mountain range.</summary>
    [InverseProperty("Mountain")]
    public virtual ICollection<PeakViewModel> Peaks { get; set; } = new List<PeakViewModel>();

    /// <summary>Countries associated with this mountain range.</summary>
    [ForeignKey("MountainId")]
    [InverseProperty("Mountains")]
    public virtual ICollection<CountryViewModel> CountryCodes { get; set; } = new List<CountryViewModel>();
}