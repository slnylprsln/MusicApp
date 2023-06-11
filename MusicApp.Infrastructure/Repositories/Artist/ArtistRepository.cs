using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Artist
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicDbContext musicDbContext;

        public ArtistRepository(MusicDbContext MusicDbContext)
        {
            musicDbContext = MusicDbContext;
        }

        public async Task CreateAsync(Entities.Artist entity)
        {
            await musicDbContext.Artists.AddAsync(entity);
            await musicDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await musicDbContext.Artists.FindAsync(id);
            musicDbContext.Artists.Remove(deleting);
            await musicDbContext.SaveChangesAsync();
        }

        public Entities.Artist? Get(int id)
        {
            return musicDbContext.Artists.FirstOrDefault(c => c.Id == id);
        }

        public IList<Entities.Artist?> GetAll()
        {
            return musicDbContext.Artists.ToList();
        }

        public async Task<IList<Entities.Artist?>> GetAllAsync()
        {
            return await musicDbContext.Artists.ToListAsync();
        }

        public IList<Entities.Artist> GetAllWithPredicate(Expression<Func<Entities.Artist, bool>> predicate)
        {
            return musicDbContext.Artists.Where(predicate).ToList();
        }

        public async Task<Entities.Artist?> GetAsync(int id)
        {
            return await musicDbContext.Artists.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Entities.Artist entity)
        {
            musicDbContext.Artists.Update(entity);
            await musicDbContext.SaveChangesAsync();
        }
    }
}
