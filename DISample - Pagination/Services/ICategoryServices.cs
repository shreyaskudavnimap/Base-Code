using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryServices
    {
        List<Category> GetCategoriesList(int pgStart, int pgLength, out int totalRecords, string searchValue);
        List<Category> GetCategoriesList(string categoryId);
        void EditCategory(string categoryId, string categoryName);
    }
}
