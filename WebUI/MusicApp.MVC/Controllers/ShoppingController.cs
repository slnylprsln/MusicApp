using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.MVC.Extensions;
using MusicApp.MVC.Models;
using MusicApp.Services.Interfaces;

namespace MusicApp.MVC.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IAlbumService albumService;

        public ShoppingController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public IActionResult Index()
        {
            var albumCollection = getAlbumCollectionFromSession();
            return View(albumCollection);
        }

        public IActionResult AddAlbum(int id)
        {
            AlbumDisplayResponse selectedAlbum = albumService.Get(id);
            var albumItem = new AlbumItem { Album = selectedAlbum, Quantity = 1 };
           
            AlbumCollection albumCollection = getAlbumCollectionFromSession();
            albumCollection.AddNewAlbum(albumItem);
            saveToSession(albumCollection);

            return Json(new { message = $"{selectedAlbum.AlbumName} Sepete eklendi" });
        }


        private AlbumCollection getAlbumCollectionFromSession()
        {
            return HttpContext.Session.GetJson<AlbumCollection>("basket") ?? new AlbumCollection();
        }


        private void saveToSession(AlbumCollection albumCollection)
        {
            HttpContext.Session.SetJson("basket", albumCollection);
        }
    }
}
