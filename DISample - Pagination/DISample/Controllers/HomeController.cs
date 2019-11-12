using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using DISample.Filters;

namespace DISample.Controllers
{

    public class HomeController : Controller, IResultFilter
    {
        private ICategoryServices _categoryService;

        public HomeController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }
        
        [CustomErrorFilter]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult EditView([Bind(Prefix = "id")]string categoryId)
        {
            var categoryList = _categoryService.GetCategoriesList(categoryId);
            ViewBag.Title = "Home Page";
            return View(categoryList);
        }

        public ActionResult Edit([Bind(Prefix = "id")]string categoryId, [Bind(Prefix = "categoryName")]string categoryName)
        {
            _categoryService.EditCategory(categoryId, categoryName); // Update
            var categoryList = _categoryService.GetCategoriesList(categoryId);

            ViewBag.Title = "Home Page";
            return View("EditView", categoryList);
        }

        public ActionResult Delete([Bind(Prefix = "id")]string categoryId)
        {
            return View();
        }

        public JsonResult EventPagination()
        {
            int totalRecords = 0;
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            // Call Category Service
            var categoryList = _categoryService.GetCategoriesList(start, length,out totalRecords);

            //Filtering
            if (!string.IsNullOrEmpty(searchValue))
            {
                categoryList = categoryList.
                    Where(x => x.ID.ToString().ToLower().Contains(searchValue.ToLower()) || x.CategoryName.ToLower().Contains(searchValue.ToLower())).ToList<Category>();
            }
            
            int totalrows = categoryList.Count;
            
            //Sorting
            categoryList = categoryList.OrderBy(sortColumnName + " " + sortDirection).ToList<Category>();

            return Json(new { data = categoryList, draw = Request["draw"], recordsTotal = totalRecords, recordsFiltered = totalRecords }, JsonRequestBehavior.AllowGet);

        }

    }
}
