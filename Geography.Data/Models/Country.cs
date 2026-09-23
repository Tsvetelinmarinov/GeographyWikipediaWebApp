using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geography.Data.Models;

/// <summary>
/// Represents a country, its identifiers, geographic measurements, and related geography records.
/// </summary>
public partial class Country
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string CountryCode { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string IsoCode { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string CountryName { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string? CurrencyCode { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string ContinentCode { get; set; } = null!;

    public int Population { get; set; }

    public int AreaInSqKm { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Capital { get; set; } = null!;

    /// <summary>The continent selected by <see cref="ContinentCode"/>.</summary>
    [ForeignKey("ContinentCode")]
    [InverseProperty("Countries")]
    public virtual Continent ContinentCodeNavigation { get; set; } = null!;

    /// <summary>The optional currency selected by <see cref="CurrencyCode"/>.</summary>
    [ForeignKey("CurrencyCode")]
    [InverseProperty("Countries")]
    public virtual Currency? CurrencyCodeNavigation { get; set; }

    /// <summary>Mountain ranges that extend through this country.</summary>
    [ForeignKey("CountryCode")]
    [InverseProperty("CountryCodes")]
    public virtual ICollection<Mountain> Mountains { get; set; } = new List<Mountain>();

    /// <summary>Rivers that flow through this country.</summary>
    [ForeignKey("CountryCode")]
    [InverseProperty("CountryCodes")]
    public virtual ICollection<River> Rivers { get; set; } = new List<River>();
}