using insurance.api.Models;
using insurance.api.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insurance.api.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceDbContext _context;
        public PolicyRepository(InsuranceDbContext context)
        {
            _context = context;
        }
        public async Task<Policy> Register(Policy policy)
        {
            // add object to the context
            await _context.AddAsync(policy);
            // Save
            await _context.SaveChangesAsync();

            return policy;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public List<Policy> GetAll()
        {
            return _context.Policy.ToList();
        }
        public async Task<Policy> GetPolicy(int id)
        {
            var policy = await _context.Policy.FirstOrDefaultAsync(u => u.Id == id);

            return policy;
        }
    }
}
