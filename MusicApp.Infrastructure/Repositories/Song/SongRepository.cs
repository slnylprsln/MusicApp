using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Song
{
    public class SongRepository : ISongRepository
    {
        private readonly MusicDbContext musicDbContext;

        public SongRepository(MusicDbContext MusicDbContext)
        {
            musicDbContext = MusicDbContext;
        }

        public async Task CreateAsync(Entities.Song entity)
        {
            await musicDbContext.Songs.AddAsync(entity);
            await musicDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await musicDbContext.Songs.FindAsync(id);
            musicDbContext.Songs.Remove(deleting);
            await musicDbContext.SaveChangesAsync();
        }

        public Entities.Song? Get(int id)
        {
            return musicDbContext.Songs.FirstOrDefault(c => c.Id == id);
        }

        public IList<Entities.Song?> GetAll()
        {
            return musicDbContext.Songs.ToList();
        }

        public async Task<IList<Entities.Song?>> GetAllAsync()
        {
            return await musicDbContext.Songs.ToListAsync();
        }

        public IList<Entities.Song> GetAllWithPredicate(Expression<Func<Entities.Song, bool>> predicate)
        {
            return musicDbContext.Songs.Where(predicate).ToList();
        }

        public async Task<Entities.Song?> GetAsync(int id)
        {
            return await musicDbContext.Songs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Entities.Song entity)
        {
            musicDbContext.Songs.Update(entity);
            await musicDbContext.SaveChangesAsync();
        }
    }
}
