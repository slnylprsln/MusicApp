using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Album
{
    public interface IAlbumRepository : IRepository<Entities.Album>
    {
        public IEnumerable<Entities.Album> GetAlbumsByArtist(int artistId);
        public Task<IEnumerable<Entities.Album>> GetAlbumsByArtistAsync(int artistId);
        public Task<IEnumerable<Entities.Album>> GetAlbumsByName (string name);
    }
}
