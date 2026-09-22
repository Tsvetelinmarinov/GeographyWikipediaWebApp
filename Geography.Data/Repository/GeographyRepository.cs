using Geography.Data.Context;
using Geography.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Repository
{
    public class GeographyRepository(GeographyContext dbContext) : IRepository
    {
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dbContext.Dispose();
        }
    }
}