using AutoMapper;
using Geography.Data.Models;
using Geography.Services.ViewModels;

namespace Geography.Services.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Continent, ContinentViewModel>();
            CreateMap<Country, CountryViewModel>();
        }
    }
}