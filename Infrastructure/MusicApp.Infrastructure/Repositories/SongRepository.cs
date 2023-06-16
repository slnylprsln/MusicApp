using Microsoft.EntityFrameworkCore;
using MusicApp.Entities;
using MusicApp.Infrastructure.Data;
using MusicApp.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly MusicDbContext musicDbContext;

        public SongRepository(MusicDbContext MusicDbContext)
        {
            musicDbContext = MusicDbContext;
        }

        public async Task CreateAsync(Song entity)
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

        public Song? Get(int id)
        {
            return musicDbContext.Songs.FirstOrDefault(c => c.Id == id);
        }

        public IList<Song?> GetAll()
        {
            return musicDbContext.Songs.ToList();
        }

        public async Task<IList<Song?>> GetAllAsync()
        {
            return await musicDbContext.Songs.ToListAsync();
        }

        public IList<Song> GetAllWithPredicate(Expression<Func<Song, bool>> predicate)
        {
            return musicDbContext.Songs.Where(predicate).ToList();
        }

        public async Task<Song?> GetAsync(int id)
        {
            return await musicDbContext.Songs.FirstOrDefaultAsync(c => c.Id == id);
        }
        public IEnumerable<Song> GetSongsByAlbum(int albumId)
        {
            return musicDbContext.Songs.AsNoTracking().Where(c => c.AlbumId == albumId).AsEnumerable();
        }
        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Song entity)
        {
            musicDbContext.Songs.Update(entity);
            await musicDbContext.SaveChangesAsync();
        }
    }
}
