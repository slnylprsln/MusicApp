using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Responses
{
    public class SongDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? RunningTime { get; set; }
        public int? AlbumId { get; set; }
    }
}
