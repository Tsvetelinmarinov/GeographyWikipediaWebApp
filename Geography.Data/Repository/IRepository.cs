using Geography.Data.Models;
using Geography.Data.ViewModels;

namespace Geography.Data.Repository
{
    /// <summary>
    /// Defines the data-access operations used by the service layer.
    /// </summary>
    public interface IRepository : IDisposable
    {
        #region ContinentsService Logic

        /// <summary>Returns every continent with its direct country collection.</summary>
        IEnumerable<Continent> GetAllContinents();

        /// <summary>Finds a continent by its two-character code.</summary>
        Continent FindContinentById(string continentCode);

        /// <summary>Returns a continent's countries with their mountains and rivers loaded.</summary>
        IEnumerable<Country> ExtractContinentCountriesWithAllData(Continent continent);

        #endregion
        #region CountriesService Logic

        /// <summary>Returns all countries as view models with related data loaded.</summary>
        IEnumerable<CountryViewModel> GetAllCountries();

        #endregion
    }
}