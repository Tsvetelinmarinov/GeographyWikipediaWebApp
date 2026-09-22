using Geography.Data.Context;
using Geography.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Geography.Data.Repository
{
    public class GeographyRepository : IRepository
    {
        // Db context instance.
        private readonly GeographyContext _dbContext;


        public IEnumerable<Continent> GetAllContinents()
        {
            return this._dbContext
                .Continents
                .AsNoTracking()
                .OrderBy((continent) => continent.ContinentCode);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}