using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Product(string id)
        {
            var productList = _productService.GetProductList(id);
            return View(productList);
        }
    }
}