using AutoMapper;
using Geography.Data.Repository;
using Geography.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geography.Services
{
    public class ContinentsService(IRepository database, IMapper autoMapper) : IContinentsService
    {
        public IEnumerable<ContinentViewModel> GetAllContinents()
        {
            var continentEntities = database.GetAllContinents();
            var continentModels = new List<ContinentViewModel>();

            // Map each entity Continet to separate view model ContinentViewModel.
            foreach(var continentEntity in continentEntities)
            {
                var currentContinentModel = autoMapper.Map<ContinentViewModel>(continentEntity);
                continentModels.Add(currentContinentModel);
            }

            return continentModels;
        }       
    }
}