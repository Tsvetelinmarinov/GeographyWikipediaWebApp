using Geography.Data.Models;

namespace Geography.Data.Repository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Continent> GetAllContinents();
    }
}