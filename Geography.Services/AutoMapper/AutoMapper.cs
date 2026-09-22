using AutoMapper;
using Geography.Data.Models;
using Geography.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geography.Services.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            this.CreateMap<Continent, ContinentViewModel>();
        }
    }
}