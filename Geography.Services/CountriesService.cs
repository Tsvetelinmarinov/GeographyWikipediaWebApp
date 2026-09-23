using Geography.Data.Repository;
using Geography.Data.ViewModels;
using Geography.Services.Interfaces;

namespace Geography.Services
{
    /// <summary>
    /// Coordinates country retrieval between the web layer and the repository.
    /// </summary>
    public class CountriesService(IRepository database) : ICountriesService
    {
        /// <summary>Delegates retrieval of all display-ready countries to the repository.</summary>
        public IEnumerable<CountryViewModel> GetAllCountries()
            => database.GetAllCountries();
    }
}