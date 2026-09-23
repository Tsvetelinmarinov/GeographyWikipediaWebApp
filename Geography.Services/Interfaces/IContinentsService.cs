using Geography.Data.ViewModels;

namespace Geography.Services.Interfaces
{
    /// <summary>
    /// Defines continent operations exposed to the web layer.
    /// </summary>
    public interface IContinentsService
    {
        /// <summary>Returns all continents prepared for display.</summary>
        IEnumerable<ContinentViewModel> GetAllContinents();

        /// <summary>Finds a continent by its code.</summary>
        ContinentViewModel FindContinentById(string continentCode);

        /// <summary>Returns countries of a continent with mountains and rivers included.</summary>
        IEnumerable<CountryViewModel> ExtractContinentCountriesWithAllData(ContinentViewModel continentModel); 
    }
}