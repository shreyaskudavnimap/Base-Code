using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        private GlobalRepository _categoryRepo = null;

        public CategoryServices()
        {
            _categoryRepo = new GlobalRepository();
        }

        List<Category> ICategoryServices.GetCategoriesList()
        {
            return _categoryRepo.GetCategoryList();
        }
    }
}
