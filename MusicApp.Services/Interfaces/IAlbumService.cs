using MusicApp.DataTransferObjects.Requests;
using MusicApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Interfaces
{
    public interface IAlbumService
    {
        Task CreateAsync(CreateNewAlbumRequest createNewAlbumRequest);
        Task<int> CreateAndReturnIdAsync(CreateNewAlbumRequest createNewAlbumRequest);
        AlbumDisplayResponse Get(int id);
        Task<UpdateAlbumRequest> GetForUpdate(int id);
        IEnumerable<AlbumDisplayResponse> GetDisplayResponses();
        IEnumerable<AlbumDisplayResponse> GetAlbumsByArtist(int id);
        Task<IEnumerable<AlbumDisplayResponse>> SearchByName(string name);
        Task Update(UpdateAlbumRequest updateAlbumRequest);
        Task<bool> IsExists(int id);
        Task DeleteAsync(int id);
    }
}
