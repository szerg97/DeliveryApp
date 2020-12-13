using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
        }

        public void DeleteCountry(Country country)
        {
            _context.Countries.Remove(country);
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries
                .ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(string countryId)
        {
            return await _context.Countries
                .SingleOrDefaultAsync(x => x.CountryId == countryId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
