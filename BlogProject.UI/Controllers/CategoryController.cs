using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.DAL.BaseRepository;
using BlogProject.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository _repo)
        {
            repository = _repo;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public IActionResult AddOrUpdate(int? id)
        {
            if (id==null)
            {
                return View(new Category());
            }
            else
            {
                return View(repository.GetById((int)id));
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Category entity)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(entity);
                TempData["message"] = $"{entity.Name} kayıt edildi";
                return RedirectToAction("List");
            }

            return View(entity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            TempData["message"] = $"{id} numaralı kayıt silinidi";
            return RedirectToAction("List");

        }
    }
}