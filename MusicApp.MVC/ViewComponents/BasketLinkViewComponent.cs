using Microsoft.AspNetCore.Mvc;
using MusicApp.MVC.Extensions;
using MusicApp.MVC.Models;

namespace MusicApp.MVC.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var albumCollection = HttpContext.Session.GetJson<AlbumCollection>("basket");
            return View(albumCollection);
        }
    }
}
