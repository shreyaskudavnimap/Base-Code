using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using DISample.Filters;
using System.Collections;

namespace DISample.Controllers
{

    public class HomeController : Controller, IResultFilter
    {
        private ICategoryServices _categoryService;
        private IProductServices _productService;
        
        public HomeController(ICategoryServices categoryService, IProductServices productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        //[CustomErrorFilter]
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

        public ActionResult Edit([Bind(Prefix = "id")]string categoryId, string categoryName)
        {
            _categoryService.EditCategory(categoryId, categoryName); // Update
            var categoryList = _categoryService.GetCategoriesList(categoryId);

            ViewBag.Title = "Home Page";
            return View("EditView", categoryList);
        }

        public ActionResult DeleteView([Bind(Prefix = "id")]string categoryId)
        {
            var categoryList = _categoryService.GetCategoriesList(categoryId);
            return View(categoryList);
        }

        public ActionResult Delete(string categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return RedirectToAction("Index");
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
            var categoryList = _categoryService.GetCategoriesList(start, length,out totalRecords, searchValue);

            //Sorting
            categoryList = categoryList.OrderBy(sortColumnName + " " + sortDirection).ToList<Category>();

            return Json(new { data = categoryList, draw = Request["draw"], recordsTotal = totalRecords, recordsFiltered = totalRecords }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Product([Bind(Prefix = "id")]string categoryId)
        {
            var productList = _productService.GetProductList(categoryId);
            return View(productList);
        }

    }
}
