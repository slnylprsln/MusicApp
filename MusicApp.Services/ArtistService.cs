using AutoMapper;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.Infrastructure.Repositories.Interfaces;
using MusicApp.Services.Extensions;
using MusicApp.Services.Interfaces;

namespace MusicApp.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IMapper _mapper;
        private readonly IArtistRepository _repository;

        public ArtistService(IMapper mapper, IArtistRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<ArtistDisplayResponse> GetArtistsForList()
        {
            var items = _repository.GetAll();
            var responses = items.ConvertArtistToDisplayResponses(_mapper);
            return responses;
        }
    }
}
