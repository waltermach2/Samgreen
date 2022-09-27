using insurance.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace insurance.api.Repositories
{
    public interface IPolicyRepository
    {
        void Delete<T>(T entity) where T : class;
        void Add<T>(T entity) where T : class;
        Task<bool> SaveAll();
        List<Policy> GetAll();
    }
}
