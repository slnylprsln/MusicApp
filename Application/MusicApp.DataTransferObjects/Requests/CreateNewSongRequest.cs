using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Requests
{
    public class CreateNewSongRequest
    {
        public string Name { get; set; }
        public double? RunningTime { get; set; }
        public int? AlbumId { get; set; }
    }
}
