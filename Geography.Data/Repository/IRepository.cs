using Geography.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geography.Data.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Continent> GetAllContinents();
    }
}