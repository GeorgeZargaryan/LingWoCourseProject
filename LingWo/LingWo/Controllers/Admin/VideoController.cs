using LingWo.Models;
using LingWo.Services.Abstract;
using LingWo.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LingWo.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VideoController(
            IVideoService videoService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _videoService = videoService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var videos = _videoService.GetAll();
            return View(videos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var video = new Video();

            return View(video);
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> Create(Video video)
        {
            if (video != null)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (files.Any())
                {
                    string upload = webRootPath + WC.VideoPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        await files[0].CopyToAsync(fileStream);
                    }

                    video.Link = fileName + extension;
                }
            }

            _videoService.Add(video);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = _videoService.GetById(id);

            return View(video);
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<IActionResult> Edit(Video video)
        {
            if (video != null)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                // check if video exists
                if (files.Any() && video.Link != files[0].FileName)
                {
                    string upload = webRootPath + WC.VideoPath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (FileStream filesStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        await files[0].CopyToAsync(filesStream);

                    // initializing attached video to database
                    video.Link = fileName + extension;
                }

                _videoService.Edit(video);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RemoveVideo(int id)
        {
            Video video = _videoService.GetById(id);

            if (video == null)
                return BadRequest();

            if (video.Link != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string videoPath = webRootPath + WC.VideoPath;

                if (System.IO.File.Exists(Path.Combine(videoPath, video.Link)))
                    System.IO.File.Delete(Path.Combine(videoPath, video.Link));

                video.Link = null;
            }

            _videoService.Edit(video);

            return RedirectToAction("Edit", new { id = video.Id });
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            Video video = _videoService.GetById(id);

            if (video != null)
            {
                // check if video exists
                if (video.Link != null)
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string videoPath = webRootPath + WC.VideoPath;

                    if (System.IO.File.Exists(Path.Combine(videoPath, video.Link)))
                        System.IO.File.Delete(Path.Combine(videoPath, video.Link));
                }

                _videoService.Remove(id);
            }

            return new JsonResult(Ok(video));
        }

    }
}
