using Geography.Services.ViewModels;

namespace Geography.Services.Continent
{
    public interface IContinentsService
    {
        IEnumerable<ContinentViewModel> GetAllContinents();
        ContinentViewModel FindContinentById(string continentCode);
        IEnumerable<CountryViewModel> ExtractContinentCountriesWithAllData(ContinentViewModel continentModel); 
    }
}