using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.ViewModels;

/// <summary>
/// View-facing representation of a continent and its countries.
/// </summary>
public partial class ContinentViewModel
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string ContinentCode { get; set; } = null!;

    [StringLength(50)]
    public string ContinentName { get; set; } = null!;

    /// <summary>Countries exposed for this continent.</summary>
    [InverseProperty("ContinentCodeNavigation")]
    public virtual ICollection<CountryViewModel> Countries { get; set; } = new List<CountryViewModel>();
}