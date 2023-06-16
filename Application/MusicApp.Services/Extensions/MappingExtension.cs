using AutoMapper;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.Entities;

namespace MusicApp.Services.Extensions
{
    public static class MappingExtension
    {
        public static T ConvertAlbumToDto<T>(this IEnumerable<Album> albums, IMapper mapper)
        {
            return mapper.Map<T>(albums);
        }

        public static T ConvertArtistToDto<T>(this IEnumerable<Artist> artists, IMapper mapper)
        {
            return mapper.Map<T>(artists);
        }

        public static T ConvertSongToDto<T>(this IEnumerable<Song> songs, IMapper mapper)
        {
            return mapper.Map<T>(songs);
        }

        public static T ConvertUserToDto<T>(this IEnumerable<User> users, IMapper mapper)
        {
            return mapper.Map<T>(users);
        }

        public static IEnumerable<AlbumDisplayResponse> ConvertAlbumToDisplayResponses(this IEnumerable<Album> albums, IMapper mapper)
        {
            return mapper.Map<IEnumerable<AlbumDisplayResponse>>(albums);
        }

        public static IEnumerable<ArtistDisplayResponse> ConvertArtistToDisplayResponses(this IEnumerable<Artist> artists, IMapper mapper)
        {
            return mapper.Map<IEnumerable<ArtistDisplayResponse>>(artists);
        }

        public static IEnumerable<SongDisplayResponse> ConvertSongToDisplayResponses(this IEnumerable<Song> songs, IMapper mapper)
        {
            return mapper.Map<IEnumerable<SongDisplayResponse>>(songs);
        }

    }
}
