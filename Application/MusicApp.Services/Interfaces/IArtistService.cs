using MusicApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Interfaces
{
    public interface IArtistService
    {
        IEnumerable<ArtistDisplayResponse> GetArtistsForList();
    }
}
