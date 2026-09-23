using AutoMapper;
using AutoMapper.QueryableExtensions;
using Geography.Data.Context;
using Geography.Data.Models;
using Geography.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Repository
{
    /// <summary>
    /// Implements geography data queries through Entity Framework Core and maps country results to view models.
    /// </summary>
    public class GeographyRepository(GeographyContext dbContext, IMapper autoMapper) : IRepository
    {
        #region ContinentsService Logic

        /// <summary>
        /// Retrieves all continents in code order, including their countries, without tracking entities.
        /// </summary>
        public IEnumerable<Continent> GetAllContinents()
        {
            return dbContext
                .Continents
                .AsNoTracking()
                .Include((continent) => continent.Countries)
                .OrderBy((continent) => continent.ContinentCode);
        }
        /// <summary>
        /// Retrieves one continent by code or throws when no matching record exists.
        /// </summary>
        public Continent FindContinentById(string continentCode)
        {
            var continent = dbContext
                .Continents
                .AsNoTracking()
                .Include((continent) => continent.Countries)
                .FirstOrDefault((continent) => continent.ContinentCode == continentCode)
                ?? throw new InvalidDataException("There is no continent with that code in the database!");

            return continent;
        }
        /// <summary>
        /// Loads the countries of a continent with their many-to-many mountain and river relationships.
        /// </summary>
        public IEnumerable<Country> ExtractContinentCountriesWithAllData(Continent continent)
        {
            var continentEntity = dbContext
                .Continents
                .AsNoTracking()
                .Include((cont) => cont.Countries)
                .ThenInclude((country) => country.Rivers)
                .Include((cont) => cont.Countries)
                .ThenInclude((country) => country.Mountains)
                .FirstOrDefault((cont) => cont.ContinentCode == continent.ContinentCode)
                ?? throw new InvalidDataException("There is no continent whit that code in the database!");

            return continentEntity.Countries;
        }

        #endregion
        #region CountriesService Logic

        /// <summary>
        /// Loads countries and their navigation properties, then projects them to view models.
        /// </summary>
        public IEnumerable<CountryViewModel> GetAllCountries()
        {
            var countries = dbContext
                .Countries
                .AsNoTracking()
                .Include((country) => country.ContinentCodeNavigation)
                .Include((country) => country.CurrencyCodeNavigation)
                .Include((country) => country.Mountains)
                .Include((country) => country.Rivers);

            return autoMapper.Map<IEnumerable<CountryViewModel>>(countries);
        }

        #endregion

        /// <summary>
        /// Releases the database context owned by this repository instance.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dbContext.Dispose();
        }
    }
}