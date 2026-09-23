using System;
using System.Collections.Generic;
using Geography.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Context;

/// <summary>
/// Entity Framework Core context for the Geography SQL Server database.
/// </summary>
public partial class GeographyContext : DbContext
{
    /// <summary>
    /// Creates a context with options supplied by dependency injection.
    /// </summary>
    public GeographyContext(DbContextOptions<GeographyContext> options)
        : base(options)
    {
    }


    /// <summary>Continents stored in the database.</summary>
    public virtual DbSet<Continent> Continents { get; set; }

    /// <summary>Countries stored in the database.</summary>
    public virtual DbSet<Country> Countries { get; set; }

    /// <summary>Currencies available to countries.</summary>
    public virtual DbSet<Currency> Currencies { get; set; }

    /// <summary>Mountain ranges and their related countries.</summary>
    public virtual DbSet<Mountain> Mountains { get; set; }

    /// <summary>Peaks that belong to mountain ranges.</summary>
    public virtual DbSet<Peak> Peaks { get; set; }

    /// <summary>Rivers and their related countries.</summary>
    public virtual DbSet<River> Rivers { get; set; }


    /// <summary>
    /// Configures the SQL Server provider for direct context usage outside dependency injection.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=DESKTOP-SVT1AQQ\\SQLEXPRESS;Database=Geography;Trusted_Connection=true;TrustServerCertificate=true;Encrypt=false;"
        );

    /// <summary>
    /// Configures column constraints and entity relationships that are not inferred automatically.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Continent>(entity =>
        {
            entity.Property(e => e.ContinentCode).IsFixedLength();
        });
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryCode).IsFixedLength();
            entity.Property(e => e.ContinentCode).IsFixedLength();
            entity.Property(e => e.CurrencyCode).IsFixedLength();
            entity.Property(e => e.IsoCode).IsFixedLength();

            entity.HasOne(d => d.ContinentCodeNavigation).WithMany(p => p.Countries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Countries_Continents");

            entity.HasOne(d => d.CurrencyCodeNavigation).WithMany(p => p.Countries).HasConstraintName("FK_Countries_Currencies");

            entity.HasMany(d => d.Rivers).WithMany(p => p.CountryCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "CountriesRiver",
                    r => r.HasOne<River>().WithMany()
                        .HasForeignKey("RiverId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CountriesRivers_Rivers"),
                    l => l.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CountriesRivers_Countries"),
                    j =>
                    {
                        j.HasKey("CountryCode", "RiverId");
                        j.ToTable("CountriesRivers");
                        j.IndexerProperty<string>("CountryCode")
                            .HasMaxLength(2)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.CurrencyCode).IsFixedLength();
        });
        modelBuilder.Entity<Mountain>(entity =>
        {
            entity.HasMany(d => d.CountryCodes).WithMany(p => p.Mountains)
                .UsingEntity<Dictionary<string, object>>(
                    "MountainsCountry",
                    r => r.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MountainsCountries_Countries"),
                    l => l.HasOne<Mountain>().WithMany()
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MountainsCountries_Mountains"),
                    j =>
                    {
                        j.HasKey("MountainId", "CountryCode").HasName("PK_MountainsContinents");
                        j.ToTable("MountainsCountries");
                        j.IndexerProperty<string>("CountryCode")
                            .HasMaxLength(2)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });
        modelBuilder.Entity<Peak>(entity =>
        {
            entity.HasOne(d => d.Mountain).WithMany(p => p.Peaks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Peaks_Mountains");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}