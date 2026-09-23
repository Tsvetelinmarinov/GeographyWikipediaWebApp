using AutoMapper;
using Geography.Data.ViewModels;
using Geography.Data.Models;

namespace Geography.Data.AutoMapper
{
    public class Mapper : Profile
    {
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