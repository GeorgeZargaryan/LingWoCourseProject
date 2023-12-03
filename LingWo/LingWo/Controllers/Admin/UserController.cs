using LingWo.Models;
using LingWo.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LingWo.Controllers.Admin
{

    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var articles = _userService.GetAll();
            return View(articles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = new ApplicationUser();

            return View(user);
        }

        [HttpPost]
        public IActionResult Create(ApplicationUser user)
        {
            _userService.Add(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var article = _userService.GetById(id);

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
        {
            _userService.Edit(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Delete(string id)
        {
            ApplicationUser user = _userService.GetById(id);

            _userService.Remove(id);

            return new JsonResult(Ok(user));
        }

    }
}
