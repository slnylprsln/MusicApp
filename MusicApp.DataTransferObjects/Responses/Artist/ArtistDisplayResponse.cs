using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Responses.Artist
{
    public class ArtistDisplayResponse
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string Nationality { get; set; }
    }
}
