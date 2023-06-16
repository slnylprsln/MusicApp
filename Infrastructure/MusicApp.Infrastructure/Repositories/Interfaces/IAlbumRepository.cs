using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        public IEnumerable<Album> GetAlbumsByArtist(int artistId);
        public Task<IEnumerable<Album>> GetAlbumsByArtistAsync(int artistId);
        public Task<IEnumerable<Album>> GetAlbumsByName(string name);
    }
}
