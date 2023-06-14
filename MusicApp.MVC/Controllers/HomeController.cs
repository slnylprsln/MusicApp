using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicApp.DataTransferObjects.Responses;
using MusicApp.MVC.CacheTools;
using MusicApp.MVC.Models;
using MusicApp.Services.Interfaces;
using System.Diagnostics;

namespace MusicApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlbumService _albumService;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IAlbumService albumService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _albumService = albumService;
            _memoryCache = memoryCache;
        }

        public IActionResult Index(int pageNo = 1, int? id = null)
        {
            IEnumerable<AlbumDisplayResponse> albums = getAlbumsMemCacheOrDb(id);

            var albumPerPage = 4;
            var albumCount = albums.Count();
            var totalPage = Math.Ceiling((decimal)albumCount / albumPerPage);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = pageNo,
                ItemsPerPage = albumPerPage,
                TotalItems = albumCount
            };

            var paginatedAlbums = albums.OrderBy(c => c.Id)
                                          .Skip((pageNo - 1) * albumPerPage)
                                          .Take(albumPerPage)
                                          .ToList();

            var model = new PaginationAlbumViewModel
            {
                Albums = paginatedAlbums,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        [ResponseCache(Duration = 70, VaryByQueryKeys = new[] { "id" }, Location = ResponseCacheLocation.Client)]
        public IActionResult Privacy(int id)
        {
            ViewBag.Id = id;
            ViewBag.DateTime = DateTime.Now;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IEnumerable<AlbumDisplayResponse> getAlbumsMemCacheOrDb(int? id)
        {
            if (!_memoryCache.TryGetValue("allAlbums", out CacheDataInfo cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal);

                cacheDataInfo = new CacheDataInfo
                {
                    CacheTime = DateTime.Now,
                    Albums = _albumService.GetDisplayResponses()
                };

                _memoryCache.Set("allAlbums", cacheDataInfo, options);
            }

            _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz");
            return id == null ? cacheDataInfo.Albums :
                                _albumService.GetAlbumsByArtist(id.Value);

        }
    }
}