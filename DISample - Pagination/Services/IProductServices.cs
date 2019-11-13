using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductServices
    {
        List<Product> GetProductList(string categoryId);
        List<Product> GetProductById(string productId);
        List<Product> GetProductList(int pgStart, int pgLength, out int totalRecords, string searchValue, string sortBy);
        void EditProduct(string productId, string productName);
        void DeleteProduct(string productId);
        void CreateProduct(string newProductName, int categoryId);
    }
}
