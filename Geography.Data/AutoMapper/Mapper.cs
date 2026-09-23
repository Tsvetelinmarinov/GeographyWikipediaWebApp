using AutoMapper;
using Geography.Data.ViewModels;
using Geography.Data.Models;

namespace Geography.Data.AutoMapper
{
    /// <summary>
    /// Defines the AutoMapper profiles used to convert between database entities and view models.
    /// </summary>
    public class Mapper : Profile
    {
        /// <summary>
        /// Registers the two-way mappings used by the application.
        /// </summary>
        public Mapper()
        {
            #region Continent -> ContinentViewModel Mapping

            CreateMap<Continent, ContinentViewModel>();
            CreateMap<ContinentViewModel, Continent>();

            #endregion
            #region County -> CountryViewModel Mapping

            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();

            #endregion
            #region River -> RiverViewModel Mapping

            CreateMap<RiverViewModel, River>();
            CreateMap<River, RiverViewModel>();

            #endregion
            #region Mountain -> MountainViewModel Mapping

            CreateMap<Mountain, MountainViewModel>();
            CreateMap<MountainViewModel, Mountain>();

            #endregion
            #region Currency -> CurrencyViewModel Mapping

            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<CurrencyViewModel, Currency>();

            #endregion
        }
    }
}
