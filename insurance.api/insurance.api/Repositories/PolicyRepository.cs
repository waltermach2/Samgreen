using insurance.api.Models;
using insurance.api.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<List<Policy>> GetAll()
        {
            return await _context.Policy.ToListAsync();
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        List<Policy> IPolicyRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
