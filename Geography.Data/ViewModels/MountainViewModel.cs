using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.ViewModels;

public partial class MountainViewModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string MountainRange { get; set; } = null!;

    [InverseProperty("Mountain")]
    public virtual ICollection<PeakViewModel> Peaks { get; set; } = new List<PeakViewModel>();

    [ForeignKey("MountainId")]
    [InverseProperty("Mountains")]
    public virtual ICollection<CountryViewModel> CountryCodes { get; set; } = new List<CountryViewModel>();
}