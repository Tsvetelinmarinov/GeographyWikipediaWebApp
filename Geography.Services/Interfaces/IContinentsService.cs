using Geography.Data.ViewModels;

namespace Geography.Services.Interfaces
{
    public interface IContinentsService
    {
        IEnumerable<ContinentViewModel> GetAllContinents();
        ContinentViewModel FindContinentById(string continentCode);
        IEnumerable<CountryViewModel> ExtractContinentCountriesWithAllData(ContinentViewModel continentModel); 
    }
}