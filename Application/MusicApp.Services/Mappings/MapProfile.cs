using AutoMapper;
using MusicApp.DataTransferObjects.Requests;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.Entities;

namespace MusicApp.Services.Mappings
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Album, AlbumDisplayResponse>();
            CreateMap<Artist, ArtistDisplayResponse>();
            CreateMap<Song, SongDisplayResponse>();

            CreateMap<CreateNewAlbumRequest, Album>();
            CreateMap<CreateNewArtistRequest, Artist>();
            CreateMap<CreateNewSongRequest, Song>();

            CreateMap<UpdateAlbumRequest, Album>().ReverseMap();
            CreateMap<UpdateArtistRequest, Artist>().ReverseMap();
            CreateMap<UpdateSongRequest, Song>().ReverseMap();
        }
    }
}
