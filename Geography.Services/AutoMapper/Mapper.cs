using AutoMapper;
using Geography.Services.ViewModels;
using Geography.Data.Models;

namespace Geography.Services.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Geography.Data.Models.Continent, ContinentViewModel>();
            CreateMap<ContinentViewModel, Data.Models.Continent>();

            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();

            CreateMap<RiverViewModel, River>();
            CreateMap<River, RiverViewModel>();

            CreateMap<Mountain, MountainViewModel>();
            CreateMap<MountainViewModel, Mountain>();
        }
    }
}