using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICountryRepository
    {
        void AddCountry(Country country);
        void DeleteCountry(Country country);
        Task<Country> GetCountryByIdAsync(string countryId);
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<bool> SaveAllAsync();
    }
}
