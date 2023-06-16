using AutoMapper;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.Infrastructure.Repositories.Interfaces;
using MusicApp.Services.Extensions;
using MusicApp.Services.Interfaces;

namespace MusicApp.Services
{
    public class SongService : ISongService
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _repository;

        public SongService(IMapper mapper, ISongRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<SongDisplayResponse> GetSongsForList()
        {
            var items = _repository.GetAll();
            var responses = items.ConvertSongToDisplayResponses(_mapper);
            return responses;
        }

        public IEnumerable<SongDisplayResponse> GetSongsOfAlbum(int albumId)
        {
            var items = _repository.GetSongsByAlbum(albumId);
            var responses = items.ConvertSongToDisplayResponses(_mapper);
            return responses;
        }
    }
}
