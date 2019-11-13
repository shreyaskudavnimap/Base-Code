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

        public void EditCategory(string categoryId, string categoryName)
        {
            _categoryRepo.EditCategory(categoryId, categoryName);
        }

        public List<Category> GetCategoriesList(int pgStart, int pgLength, out int totalRecords, string searchValue)
        {
            return _categoryRepo.GetCategoryList(pgStart, pgLength, out totalRecords, searchValue);
        }

        public List<Category> GetCategoriesList(string categoryId)
        {
            return _categoryRepo.GetCategoryList(categoryId);
        }

        public void DeleteCategory(string categoryId)
        {
            _categoryRepo.DeleteCategory(categoryId);
        }
    }
}
