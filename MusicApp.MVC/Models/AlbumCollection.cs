using MusicApp.DataTransferObjects.Responses;

namespace MusicApp.MVC.Models
{
    public class AlbumCollection
    {
        public List<AlbumItem> AlbumItems { get; set; } = new List<AlbumItem>();

        public void ClearAll() => AlbumItems.Clear();
        public decimal TotalAlbumPrice() => AlbumItems.Sum(item => (decimal)item.Album.Price * item.Quantity);

        public int TotalAlbumsCount() => AlbumItems.Sum(p => p.Quantity);

        public void AddNewAlbum(AlbumItem albumItem)
        {
            var exists = AlbumItems.FirstOrDefault(c => c.Album.Id == albumItem.Album.Id);
            if (exists != null)
            {
                exists.Quantity += albumItem.Quantity;
            }
            else
            {
                AlbumItems.Add(albumItem);
            }

        }
    }

    public class AlbumItem
    {
        public AlbumDisplayResponse Album { get; set; }
        public int Quantity { get; set; }
        public bool? ApplyCoupon { get; set; }

    }
}
