using API.DTOs;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetSites();
        Task<Site> GetSite(string siteId);
        void AddSite(Site site);
        void DeleteSite(Site site);
        void UpdateSite(Site site);
        Task<bool> SaveAllAsync();
    }
}
