using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class SiteRepository : ISiteRepository
    {
        private readonly ApplicationDbContext _context;

        public SiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSite(Site site)
        {
            _context.Sites.Add(site);
        }

        public void DeleteSite(Site site)
        {
            _context.Sites.Remove(site);
        }

        public async Task<Site> GetSite(string siteId)
        {
            return await _context.Sites.SingleOrDefaultAsync(x => x.SiteId == siteId);
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateSite(Site site)
        {
            _context.Entry(site).State = EntityState.Modified;
        }
    }
}
