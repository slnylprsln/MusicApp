using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Album
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicDbContext musicDbContext;

        public AlbumRepository(MusicDbContext MusicDbContext)
        {
            musicDbContext = MusicDbContext;
        }

        public async Task CreateAsync(Entities.Album entity)
        {
            await musicDbContext.Albums.AddAsync(entity);
            await musicDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await musicDbContext.Albums.FindAsync(id);
            musicDbContext.Albums.Remove(deleting);
            await musicDbContext.SaveChangesAsync();
        }

        public Entities.Album? Get(int id)
        {
            return musicDbContext.Albums.FirstOrDefault(c => c.Id == id);
        }

        public IList<Entities.Album?> GetAll()
        {
            return musicDbContext.Albums.ToList();
        }

        public async Task<IList<Entities.Album?>> GetAllAsync()
        {
            return await musicDbContext.Albums.ToListAsync();
        }

        public IList<Entities.Album> GetAllWithPredicate(Expression<Func<Entities.Album, bool>> predicate)
        {
            return musicDbContext.Albums.Where(predicate).ToList();
        }

        public async Task<Entities.Album?> GetAsync(int id)
        {
            return await musicDbContext.Albums.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Entities.Album entity)
        {
            musicDbContext.Albums.Update(entity);
            await musicDbContext.SaveChangesAsync();
        }

        public IEnumerable<Entities.Album> GetAlbumsByArtist(int artistId)
        {
            return musicDbContext.Albums.AsNoTracking().Where(c => c.ArtistId == artistId).AsEnumerable();
        }

        public async Task<IEnumerable<Entities.Album>> GetAlbumsByArtistAsync(int artistId)
        {
            return await musicDbContext.Albums.AsNoTracking().Where(c => c.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Album>> GetAlbumsByName(string name)
        {
            return await musicDbContext.Albums.AsNoTracking().Where(c => c.AlbumName.Contains(name)).ToListAsync();
        }
    }
}
