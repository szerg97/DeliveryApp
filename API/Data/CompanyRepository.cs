using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies
                .Include(c => c.Creator)
                .ToListAsync();
        }

        public async Task<Company> GetCompany(string companyId)
        {
            return await _context.Companies
                .Include(c => c.Creator)
                .SingleOrDefaultAsync(x => x.CompanyId == companyId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
