using AutoMapper;
using AutoMapper.QueryableExtensions;
using Geography.Data.Context;
using Geography.Data.Models;
using Geography.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Repository
{
    public class GeographyRepository(GeographyContext dbContext, IMapper autoMapper) : IRepository
    {
        #region ContinentsService Logic

        public IEnumerable<Continent> GetAllContinents()
        {
            return dbContext
                .Continents
                .AsNoTracking()
                .Include((continent) => continent.Countries)
                .OrderBy((continent) => continent.ContinentCode);
        }
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dbContext.Dispose();
        }
    }
}