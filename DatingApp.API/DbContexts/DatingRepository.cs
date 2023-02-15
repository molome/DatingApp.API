using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.DbContexts
{
    public class DatingRepository : IDatingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DatingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dbContext.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.ID == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dbContext.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
