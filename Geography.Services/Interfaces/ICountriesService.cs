using Geography.Data.ViewModels;

namespace Geography.Services.Interfaces
{
    /// <summary>
    /// Defines country operations exposed to the web layer.
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>Returns all countries prepared for display.</summary>
        IEnumerable<CountryViewModel> GetAllCountries(); 
    }
}