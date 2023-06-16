using Microsoft.AspNetCore.Mvc;
using MusicApp.Services.Interfaces;

namespace MusicApp.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IArtistService artistService;

        public MenuViewComponent(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IViewComponentResult Invoke()
        {
            var artists = artistService.GetArtistsForList();
            return View(artists);
        }
    }
}
