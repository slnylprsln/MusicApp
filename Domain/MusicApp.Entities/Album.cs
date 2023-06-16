using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Entities
{
    public class Album : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string AlbumName { get; set; }
        public int? ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; } = "https://loremflickr.com/320/240/song";
        public ICollection<Song> Songs { get; set; }
    }
}
