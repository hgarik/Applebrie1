using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers.Models;
using WebApi.Models;

namespace WebApi.Data.Repository
{
    public class UserRepository : IRepository
    {
        private readonly TaskContext _context;
        public UserRepository(TaskContext dbContext)
        {
            this._context = dbContext;
        }


        public async Task<User> Add(IBaseEntity obj)
        {
            var user = (User)obj;
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(int userId)
        {
            var entity = await _context.Set<User>().FindAsync(userId);
            if (entity == null)
            {
                return null;
            }

            _context.Set<User>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task<List<User>> GetUsers(FilterObj obj)
        {
            if (obj.UserId != null)
            {
                return new List<User> { await _context.User.FirstOrDefaultAsync(u => u.Id == obj.UserId) };
            }

            var users = await _context.User.AsNoTracking().
                Where(u => (obj.Category == null || u.CategoryId == obj.Category)
                           && (obj.StartDate == null || u.CreationTime >= obj.StartDate)
                           && (obj.EndDate == null || u.CreationTime <= obj.EndDate))
                            .ToListAsync();

            return users;
        }

        public async Task<User> Update(IBaseEntity obj)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == obj.Id);
            var newUser = (User)obj;
            if (user == null)
                return null;

            user.CategoryId = newUser.CategoryId ?? user.CategoryId;
            user.CreationTime = newUser.CreationTime ?? user.CreationTime;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (User)obj;
        }

    }
}
