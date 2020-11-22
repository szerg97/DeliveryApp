using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Offer> GetOfferByIdAsync(string id)
        {
            return await _context.Offers
                .Include(o => o.Creator)
                .Include(o => o.Company)
                .SingleOrDefaultAsync(x => x.OfferId == id);
        }

        public async Task<IEnumerable<Offer>> GetOffersByCreatorIdAsync(string id)
        {
            return await _context.Offers
                .Include(o => o.Creator)
                .Include(o => o.Company)
                .Where(x => x.CreatorId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await _context.Offers
                .Include(o => o.Creator)
                .Include(o => o.Company)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Offer offer)
        {
            _context.Entry(offer).State = EntityState.Modified;
        }
    }
}
