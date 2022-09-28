using insurance.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace insurance.api.Repositories
{
    public interface IPolicyRepository
    {
        void Delete<T>(T entity) where T : class;
        Task<Policy> Register(Policy policy);
        Task<bool> SaveAll();
        List<Policy> GetAll();
        Task<Policy> GetPolicy(int id);
    }
}
