using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Entities
{
    public class Song : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double? RunningTime { get; set; }
        public int? AlbumId { get; set; }
        public Album? Album { get; set; }
    }
}
