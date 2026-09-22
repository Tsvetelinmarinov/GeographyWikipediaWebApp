using Geography.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geography.Services
{
    public interface IContinentsService
    {
        IEnumerable<ContinentViewModel> GetAllContinents();
    }
}