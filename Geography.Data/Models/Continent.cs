using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Models;

/// <summary>
/// Represents a continent and its associated countries in the database.
/// </summary>
public partial class Continent
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string ContinentCode { get; set; } = null!;

    [StringLength(50)]
    public string ContinentName { get; set; } = null!;

    /// <summary>Countries assigned to this continent.</summary>
    [InverseProperty("ContinentCodeNavigation")]
    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}