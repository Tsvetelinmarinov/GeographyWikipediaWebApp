using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.ViewModels;

/// <summary>
/// View-facing representation of a peak and its parent mountain range.
/// </summary>
public partial class PeakViewModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string PeakName { get; set; } = null!;

    public int Elevation { get; set; }

    public int MountainId { get; set; }

    /// <summary>The mountain range that contains this peak.</summary>
    [ForeignKey("MountainId")]
    [InverseProperty("Peaks")]
    public virtual MountainViewModel Mountain { get; set; } = null!;
}