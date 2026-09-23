using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.ViewModels;

public partial class RiverViewModel
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

    [ForeignKey("RiverId")]
    [InverseProperty("Rivers")]
    public virtual ICollection<CountryViewModel> CountryCodes { get; set; } = new List<CountryViewModel>();
}