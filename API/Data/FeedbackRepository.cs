using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void AddFeedback(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
        }

        public void DeleteFeedback(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _context.Feedbacks
                    .Include(f => f.Creator)
                    .OrderByDescending(f => f.Date)
                    .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            if (await _context.SaveChangesAsync() > 0) return true;
            return false;
        }
    }
}
