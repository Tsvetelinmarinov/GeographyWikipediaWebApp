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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dbContext.Dispose();
        }
    }
}