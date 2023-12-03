using LingWo.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LingWo.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult Watch(int id)
        {
            var videos = _videoService.GetById(id);
            return View(videos);
        }
    }
}
