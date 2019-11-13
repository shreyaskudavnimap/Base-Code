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
    public class ProductController : Controller
    {
        private IProductServices _productService;

        public ProductController(IProductServices productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Edit([Bind(Prefix = "id")]string productId, string productName)
        {
            _productService.EditProduct(productId, productName); // Update
            var categoryList = _productService.GetProductById(productId);

            ViewBag.Title = "Home Page";
            return View("EditView", categoryList);
        }
        
        public ActionResult DeleteView([Bind(Prefix = "id")]string categoryId)
        {
            var categoryList = _productService.GetProductById(categoryId);
            return View(categoryList);
        }

        public ActionResult Delete(string productId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("Product");
        }

        public ActionResult Create(FormCollection fc)
        {
            string newProductName = fc.Get("productName");
            int categoryId = Convert.ToInt32(fc.Get("categoryId"));
            _productService.CreateProduct(newProductName, categoryId);
            return View("Product");
        }

        public ActionResult CreateView()
        {
            return View();
        }

        public ActionResult ProductDetail([Bind(Prefix = "id")]string categoryId)
        {
            var productDetail = _productService.GetProductById(categoryId);

            return View(productDetail);
        }

        public ActionResult EditView([Bind(Prefix = "id")]string categoryId)
        {
            var productDetail = _productService.GetProductById(categoryId);
            ViewBag.Title = "Home Page";
            return View(productDetail);
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
            var categoryList = _productService.GetProductList(start, length, out totalRecords, searchValue, sortColumnName + " " + sortDirection);

            //Sorting
            //categoryList = categoryList.OrderBy(sortColumnName + " " + sortDirection).ToList<Product>();

            return Json(new { data = categoryList, draw = Request["draw"], recordsTotal = totalRecords, recordsFiltered = totalRecords }, JsonRequestBehavior.AllowGet);

        }

    }
}