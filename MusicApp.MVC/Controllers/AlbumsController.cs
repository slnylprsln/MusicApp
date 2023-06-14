using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicApp.DataTransferObjects.Requests;
using MusicApp.Services.Interfaces;

namespace MusicApp.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly IArtistService artistService;

        public AlbumsController(IAlbumService albumService, IArtistService artistService)
        {
            this.albumService = albumService;
            this.artistService = artistService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var albums = albumService.GetDisplayResponses();
            return View(albums);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Artists = getArtistsForSelectList();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateNewAlbumRequest request)
        {
            if (ModelState.IsValid)
            {
                await albumService.CreateAsync(request);
                return RedirectToAction(nameof(Index));
            }


            ViewBag.Artists = getArtistsForSelectList();
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Artists = getArtistsForSelectList();
            var album = await albumService.GetForUpdate(id);

            return View(album);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateAlbumRequest updateAlbumRequest)
        {
            if (await albumService.IsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await albumService.Update(updateAlbumRequest);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Artists = getArtistsForSelectList();
                return View();
            }
            return NotFound();
        }


        private IEnumerable<SelectListItem> getArtistsForSelectList()
        {
            var artists = artistService.GetArtistsForList().Select(c => new SelectListItem { Text = c.ArtistName, Value = c.Id.ToString() }).ToList();
            return artists;
        }
    }
}
