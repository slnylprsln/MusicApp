using MusicApp.DataTransferObjects.Responses;

namespace MusicApp.MVC.Models
{
    public class PaginationAlbumViewModel
    {
        public IEnumerable<AlbumDisplayResponse> Albums { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
