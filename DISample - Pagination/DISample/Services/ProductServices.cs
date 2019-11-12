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
    }
}
