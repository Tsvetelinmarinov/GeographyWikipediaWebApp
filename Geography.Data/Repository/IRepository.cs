using Geography.Data.Models;

namespace Geography.Data.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Continent> GetAllContinents();
        Continent FindContinentById(string continentCode);
        IEnumerable<Country> ExtractContinentCountriesWithAllData(Continent continent);
    }
}