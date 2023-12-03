using LingWo.Models;
using LingWo.Models.ViewModels;
using LingWo.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LingWo.Controllers.Admin
{

    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var blog = new BlogVM()
            {
                Blog = new Blog(),
                RelatedBlogs = _blogService.GetDropDown()
            };

            return View(blog);
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            _blogService.Add(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blog = _blogService.GetById(id);

            BlogVM blogVM = new BlogVM(){
                Blog = blog,
                RelatedBlogs = _blogService.GetDropDown()
            };

            return View(blogVM);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            _blogService.Edit(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {

            Blog blog = _blogService.GetById(id);

            _blogService.Remove(id);

            return new JsonResult(Ok(blog));
        }
    }
}
