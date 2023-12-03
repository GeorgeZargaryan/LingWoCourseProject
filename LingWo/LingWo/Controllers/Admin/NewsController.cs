using LingWo.Models;
using LingWo.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LingWo.Controllers.Admin
{

    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private readonly IArticleService _articleService;
        public NewsController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var articles = _articleService.GetAll();
            return View(articles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var article = new Article();

            return View(article);
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            _articleService.Add(article);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = _articleService.GetById(id);

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            _articleService.Edit(article);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            Article article = _articleService.GetById(id);

            _articleService.Remove(id);

            return new JsonResult(Ok(article));
        }

    }
}
