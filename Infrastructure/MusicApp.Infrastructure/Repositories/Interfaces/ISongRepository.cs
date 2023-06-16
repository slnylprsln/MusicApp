using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Repositories.Interfaces
{
    public interface ISongRepository : IRepository<Song>
    {
        IEnumerable<Song> GetSongsByAlbum(int albumId);
    }
}
