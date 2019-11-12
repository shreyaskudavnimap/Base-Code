using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository
    {
        public List<Category> GetCategoryList()
        {
            dynamic result;
            string connStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (var connection = new SqlConnection(connStr))
            {
                result = connection.Query<Category>("usp_GetCategory", commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }   
    }
}
