using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _context.Users
                .Include(u => u.Feedbacks)
                .Include(u => u.Offers)
                .Include(u => u.Companies)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                .Include(u => u.Feedbacks)
                .Include(u => u.Offers)
                .Include(u => u.Companies)
                .SingleOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Feedbacks)
                .Include(u => u.Offers)
                .Include(u => u.Companies)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
