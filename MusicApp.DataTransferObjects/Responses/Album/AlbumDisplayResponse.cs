using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Responses.Album
{
    public class AlbumDisplayResponse
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int? ArtistId { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; } = "https://loremflickr.com/320/240/song";
    }
}
