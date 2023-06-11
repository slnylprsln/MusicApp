using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicDbContext musicDbContext;

        public UserRepository(MusicDbContext MusicDbContext)
        {
            musicDbContext = MusicDbContext;
        }

        public async Task CreateAsync(Entities.User entity)
        {
            await musicDbContext.Users.AddAsync(entity);
            await musicDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await musicDbContext.Users.FindAsync(id);
            musicDbContext.Users.Remove(deleting);
            await musicDbContext.SaveChangesAsync();
        }

        public Entities.User? Get(int id)
        {
            return musicDbContext.Users.FirstOrDefault(c => c.Id == id);
        }

        public IList<Entities.User?> GetAll()
        {
            return musicDbContext.Users.ToList();
        }

        public async Task<IList<Entities.User?>> GetAllAsync()
        {
            return await musicDbContext.Users.ToListAsync();
        }

        public IList<Entities.User> GetAllWithPredicate(Expression<Func<Entities.User, bool>> predicate)
        {
            return musicDbContext.Users.Where(predicate).ToList();
        }

        public async Task<Entities.User?> GetAsync(int id)
        {
            return await musicDbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Entities.User entity)
        {
            musicDbContext.Users.Update(entity);
            await musicDbContext.SaveChangesAsync();
        }
    }
}
