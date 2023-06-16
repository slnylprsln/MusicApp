using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Requests
{
    public class UpdateSongRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? RunningTime { get; set; }
        public int? AlbumId { get; set; }
    }
}
