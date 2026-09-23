using AutoMapper;
using Geography.Data.ViewModels;
using Geography.Data.Models;

namespace Geography.Data.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Continent, ContinentViewModel>();
            CreateMap<ContinentViewModel, Continent>();

            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();

            CreateMap<RiverViewModel, River>();
            CreateMap<River, RiverViewModel>();

            CreateMap<Mountain, MountainViewModel>();
            CreateMap<MountainViewModel, Mountain>();
        }
    }
}