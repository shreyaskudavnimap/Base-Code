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
    public class ProductRepository
    {
        public List<Product> GetProductList(string categoryId)
        {
            dynamic result;
            string connStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("CategoryId", categoryId);
            using (var connection = new SqlConnection(connStr))
            {
                result = connection.Query<Product>("usp_GetProduct", commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }
    }
}
