using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Models;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private GlobalRepository _productRepo = null;

        public ProductServices()
        {
            _productRepo = new GlobalRepository();
        }

        public List<Product> GetProductList(string categoryId)
        {
            return _productRepo.GetProductList(categoryId);
        }

        public List<Product> GetProductById(string productId)
        {
            return _productRepo.GetProductById(productId);
        }

        public List<Product> GetProductList(int pgStart, int pgLength, out int totalRecords, string searchValue, string sortBy)
        {
            return _productRepo.GetProductList(pgStart, pgLength, out totalRecords, searchValue, sortBy);
        }

        public void EditProduct(string productId, string productName)
        {
            _productRepo.EditProduct(productId, productName);
        }

        public void DeleteProduct(string productId)
        {
            _productRepo.DeleteProduct(productId);
        }

        public void CreateProduct(string newProductName, int categoryId)
        {
            _productRepo.CreateProduct(newProductName, categoryId);
        }
    }
}
