using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Requests.Artist
{
    public class CreateNewArtistRequest
    {
        public string ArtistName { get; set; }
        public string Nationality { get; set; }
    }
}
