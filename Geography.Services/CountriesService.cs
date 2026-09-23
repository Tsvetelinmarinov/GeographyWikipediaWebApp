using Geography.Data.Repository;
using Geography.Data.ViewModels;
using Geography.Services.Interfaces;

namespace Geography.Services
{
    public class CountriesService(IRepository database) : ICountriesService
    {
        public IEnumerable<CountryViewModel> GetAllCountries()
            => database.GetAllCountries();
    }
}