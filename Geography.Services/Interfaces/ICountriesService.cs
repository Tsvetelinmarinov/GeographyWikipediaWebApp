using Geography.Data.ViewModels;

namespace Geography.Services.Interfaces
{
    public interface ICountriesService
    {
        IEnumerable<CountryViewModel> GetAllCountries(); 
    }
}