using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure.Data
{
    public class DbSeeding
    {
        public static void SeedDatabase(MusicDbContext dbContext)
        {
            seedArtistIfNotExists(dbContext);
            seedAlbumIfNotExists(dbContext);
            seedSongIfNotExists(dbContext);
            seedUserIfNotExists(dbContext);
        }

        private static void seedArtistIfNotExists(MusicDbContext dbContext)
        {
            if (!dbContext.Artists.Any())
            {
                var artists = new List<Artist>() {
                 new() { ArtistName = "Taylor Swift", Nationality = "American"  },
                 new() { ArtistName = "Stray Kids", Nationality = "Korean"  },
                 new() { ArtistName = "5 Seconds of Summer", Nationality = "Australian"  },
                };

                dbContext.Artists.AddRange(artists);
                dbContext.SaveChanges();
            }
        }

        private static void seedAlbumIfNotExists(MusicDbContext dbContext)
        {
            if (!dbContext.Albums.Any())
            {
                var albums = new List<Album>() {
                 new() { AlbumName = "Midnights", Description = "...", Price = 20, ArtistId = 1, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9f/Midnights_-_Taylor_Swift.png" },
                 new() { AlbumName = "NOEASY", Description = "...", Price = 17, ArtistId = 2, ImageUrl = "https://i.scdn.co/image/ab67616d0000b2731843897a2a72dd5036bbb1fc" },
                 new() { AlbumName = "CALM", Description = "...", Price = 18, ArtistId = 3, ImageUrl = "https://data.opus3a.com/product_photo/8b/8bb0e7c9bd443833e2e5c99060895e2b/MAX/c205deb3cd2fb3879221006b0f8f95a7.jpg" },
                };

                dbContext.Albums.AddRange(albums);
                dbContext.SaveChanges();
            }
        }

        private static void seedSongIfNotExists(MusicDbContext dbContext)
        {
            if (!dbContext.Songs.Any())
            {
                var songs = new List<Song>() {
                 new() { Name = "Maroon", RunningTime = 3.38, AlbumId = 1  },
                 new() { Name = "Karma", RunningTime = 3.24, AlbumId = 1  },
                 new() { Name = "Bejeweled", RunningTime = 3.14, AlbumId = 1  },
                 new() { Name = "Thunderous", RunningTime = 3.03, AlbumId = 2  },
                 new() { Name = "DOMINO", RunningTime = 3.18, AlbumId = 2 },
                 new() { Name = "Silent Cry", RunningTime = 3.29, AlbumId = 2 },
                 new() { Name = "No Shame", RunningTime = 3.12, AlbumId = 3 },
                 new() { Name = "Lover of Mine", RunningTime = 3.26, AlbumId = 3 },
                 new() { Name = "Old Me", RunningTime = 3.06, AlbumId = 3 },
                };

                dbContext.Songs.AddRange(songs);
                dbContext.SaveChanges();
            }
        }

        private static void seedUserIfNotExists(MusicDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = new List<User>() {
                 new() { NameSurname = "Selenay Alparslan", Email = "test1@gmail.com", Password = "1234Abcd!", Role = Role.Admin, Username = "selenaya" },
                 new() { NameSurname = "Türkay Ürkmez", Email = "test2@gmail.com", Password = "1234Abcd!", Role = Role.Admin, Username = "turkayu" },
                 new() { NameSurname = "İsim Soyisim", Email = "test3@gmail.com", Password = "1234Abcd!", Role = Role.Listener, Username = "isims" },
                };

                dbContext.Users.AddRange(users);
                dbContext.SaveChanges();
            }
        }

    }
}
