using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISample.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryServices _categoryService;

        public HomeController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categoryList = _categoryService.GetCategoriesList();

            ViewBag.Title = "Home Page";

            return View(categoryList);
        }

        
    }
}
