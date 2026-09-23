using AutoMapper;
using Geography.Data.Repository;
using Geography.Services.Interfaces;
using Geography.Data.ViewModels;

namespace Geography.Services
{
    /// <summary>
    /// Coordinates continent queries and maps repository entities to view models.
    /// </summary>
    public class ContinentsService(IRepository database, IMapper autoMapper) : IContinentsService
    {
        /// <summary>
        /// Retrieves the countries of a continent with their geographic collections populated.
        /// </summary>
        public IEnumerable<CountryViewModel> ExtractContinentCountriesWithAllData(ContinentViewModel continentModel)
        {
            var continentEntity = autoMapper.Map<Data.Models.Continent>(continentModel);
            var countryEntities = database.ExtractContinentCountriesWithAllData(continentEntity);

            if (countryEntities is null || countryEntities.Any() is false)
            {
                throw new InvalidDataException("Something went wrong while extracting the countries data from the continent database object!");
            }

            List<CountryViewModel> countryModels = [];

            foreach (var countryEntity in countryEntities)
            {
                countryModels.Add(autoMapper.Map<CountryViewModel>(countryEntity));
            }

            return countryModels;
        }
        
        /// <summary>
        /// Finds a continent by code and maps it to a view model.
        /// </summary>
        public ContinentViewModel FindContinentById(string continentCode)
        {
            var continent = database.FindContinentById(continentCode);
            var continentModel = autoMapper.Map<ContinentViewModel>(continent);
            return continentModel;
        }
        
        /// <summary>
        /// Retrieves all continents and maps each database entity to a view model.
        /// </summary>
        public IEnumerable<ContinentViewModel> GetAllContinents()
        {
            var continentEntities = database.GetAllContinents();
            var continentModels = new List<ContinentViewModel>();

            // Map each entity Continent to separate view model ContinentViewModel.
            foreach(var continentEntity in continentEntities)
            {
                var currentContinentModel = autoMapper.Map<ContinentViewModel>(continentEntity);
                continentModels.Add(currentContinentModel);
            }

            return continentModels;
        }       
    }
}