using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.ViewModels;

public partial class PeakViewModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string PeakName { get; set; } = null!;

    public int Elevation { get; set; }

    public int MountainId { get; set; }

    [ForeignKey("MountainId")]
    [InverseProperty("Peaks")]
    public virtual MountainViewModel Mountain { get; set; } = null!;
}
