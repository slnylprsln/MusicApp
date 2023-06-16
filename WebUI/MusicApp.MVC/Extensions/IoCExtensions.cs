using MusicApp.Services.Interfaces;
using MusicApp.Services;
using MusicApp.Infrastructure.Repositories.Interfaces;
using MusicApp.Infrastructure.Repositories;
using MusicApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.MVC.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();

            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<ISongService, SongService>();
            services.AddScoped<ISongRepository, SongRepository>();

            services.AddScoped<IUserService, UserService>();

            //IoC
            services.AddDbContext<MusicDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
