using LingWo.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LingWo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IArticleService _articleService;
    private readonly IBlogService _blogService;
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;
    private readonly IVideoService _videoService;

    public HomeController(
        ILogger<HomeController> logger,
        IArticleService articleService,
        IBlogService blogService,
        ICommentService commentService,
        IUserService userService,
        IVideoService videoService
        )
    {
        _logger = logger;
        _articleService = articleService;
        _blogService = blogService;
        _commentService = commentService;
        _userService = userService;
        _videoService = videoService;
    }

    public IActionResult Index()
    {
        ViewData["ArticlesCount"] = _articleService.GetAll().Count();
        ViewData["BlogsCount"] = _blogService.GetAll().Count();
        ViewData["UsersCount"] = _userService.GetAll().Count();
        ViewData["CommentsCount"] = _commentService.GetAll().Count();
        ViewData["VideosCount"] = _videoService.GetAll().Count();

        var videos = _videoService.GetAll();

        return View(videos);
    }

    public ActionResult RenderMenu()
    {
        return PartialView("_HomeHeaderPartial");
    }
}
