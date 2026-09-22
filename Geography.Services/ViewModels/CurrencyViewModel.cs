using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Services.ViewModels;

public partial class CurrencyViewModel
{
    [Key]
    [StringLength(3)]
    [Unicode(false)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(200)]
    public string Description { get; set; } = null!;

    [InverseProperty("CurrencyCodeNavigation")]
    public virtual ICollection<CountryViewModel> Countries { get; set; } = new List<CountryViewModel>();
}