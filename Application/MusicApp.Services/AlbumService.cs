using AutoMapper;
using MusicApp.DataTransferObjects.Requests;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.Entities;
using MusicApp.Infrastructure.Repositories.Interfaces;
using MusicApp.Services.Extensions;
using MusicApp.Services.Interfaces;

namespace MusicApp.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAndReturnIdAsync(CreateNewAlbumRequest createNewAlbumRequest)
        {
            var album = _mapper.Map<Album>(createNewAlbumRequest);
            await _repository.CreateAsync(album);
            return album.Id;
        }

        public async Task CreateAsync(CreateNewAlbumRequest createNewAlbumRequest)
        {
            var album = _mapper.Map<Album>(createNewAlbumRequest);
            await _repository.CreateAsync(album);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public AlbumDisplayResponse Get(int id)
        {
            var album = _repository.Get(id);
            return _mapper.Map<AlbumDisplayResponse>(album);
        }

        public IEnumerable<AlbumDisplayResponse> GetAlbumsByArtist(int id)
        {
            var albums = _repository.GetAlbumsByArtist(id);
            var response = albums.ConvertAlbumToDisplayResponses(_mapper);
            return response;
        }

        public IEnumerable<AlbumDisplayResponse> GetDisplayResponses()
        {
            var albums = _repository.GetAll();
            var responses = albums.ConvertAlbumToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<UpdateAlbumRequest> GetForUpdate(int id)
        {
            var album = await _repository.GetAsync(id);
            return _mapper.Map<UpdateAlbumRequest>(album);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public async Task<IEnumerable<AlbumDisplayResponse>> SearchByName(string name)
        {
            var albums = await _repository.GetAlbumsByName(name);
            return albums.ConvertAlbumToDisplayResponses(_mapper);
        }

        public async Task Update(UpdateAlbumRequest updateAlbumRequest)
        {
            var album = _mapper.Map<Album>(updateAlbumRequest);
            await _repository.UpdateAsync(album);
        }
    }
}
