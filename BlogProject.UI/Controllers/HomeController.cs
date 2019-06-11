using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.DAL.BaseRepository;
using BlogProject.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;

        public HomeController(IBlogRepository repository)
        {
            blogRepository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeBlogModel();

            model.HomeBlogs = blogRepository.GetAll().Where(x => x.isActive && x.isHome).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(x => x.isActive && x.isSlider).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}