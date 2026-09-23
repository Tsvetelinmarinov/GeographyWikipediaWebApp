using Geography.Data.Models;
using Geography.Data.ViewModels;

namespace Geography.Data.Repository
{
    public interface IRepository : IDisposable
    {
        #region ContinentsService Logic

        IEnumerable<Continent> GetAllContinents();
        Continent FindContinentById(string continentCode);
        IEnumerable<Country> ExtractContinentCountriesWithAllData(Continent continent);

        #endregion
        #region CountriesService Logic

        IEnumerable<CountryViewModel> GetAllCountries();

        #endregion
    }
}