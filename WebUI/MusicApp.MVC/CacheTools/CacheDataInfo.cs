using MusicApp.DataTransferObjects.Responses;

namespace MusicApp.MVC.CacheTools
{
    public class CacheDataInfo
    {
        public IEnumerable<AlbumDisplayResponse> Albums { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
