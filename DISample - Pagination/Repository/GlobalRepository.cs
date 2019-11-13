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
using Repository;

namespace Repository
{
    public class GlobalRepository 
    {
        public List<Category> GetCategoryList(int pgStart, int pgLength, out int totalRecords, string searchValue)
        {
            dynamic result;
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@START", pgStart);
                param.Add("@LENGTH", pgLength);
                param.Add("@SEARCH", searchValue);
                param.Add("@TOTALRECORDS", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = connection.Query<Category>("usp_GetCategory", param, commandType: CommandType.StoredProcedure).ToList();
                totalRecords = param.Get<int>("TOTALRECORDS");

                
            }

            return result;
        }

        public List<Product> GetProductList(string categoryId)
        {
            dynamic result;
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", Convert.ToInt32(categoryId));
            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<Product>("usp_GetProduct", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

        public List<Product> GetProductById(string productId)
        {
            dynamic result;
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", Convert.ToInt32(productId));
            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<Product>("usp_GetProductMasterById", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }
        
        public List<Category> GetCategoryList(string categoryId)
        {
            dynamic result;
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", Convert.ToInt32(categoryId));
            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<Category>("usp_GetCategoryById", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }
        
        public void EditCategory(string categoryId, string categoryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", Convert.ToInt32(categoryId));
            param.Add("@CategoryName", categoryName);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Query<Product>("usp_EditCategory", param, commandType: CommandType.StoredProcedure);
            }
            
        }

        public void EditProduct(string productId, string productName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", Convert.ToInt32(productId));
            param.Add("@ProductName", productName);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Query<Product>("usp_EditProduct", param, commandType: CommandType.StoredProcedure);
            }

        }

        public void DeleteCategory(string categoryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", Convert.ToInt32(categoryId));
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Query<Product>("usp_DeleteCategory", param, commandType: CommandType.StoredProcedure);
            }

        }

        public void DeleteProduct(string productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", Convert.ToInt32(productId));
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Query<Product>("usp_DeleteProduct", param, commandType: CommandType.StoredProcedure);
            }

        }

        public void CreateProduct(string newProductName, int categoryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            DynamicParameters param = new DynamicParameters();
            param.Add("@NewProductName",newProductName);
            param.Add("@CategoryId", Convert.ToInt32(categoryId));
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Query<Product>("usp_CreateProduct", param, commandType: CommandType.StoredProcedure);
            }
        }
        
        public List<Product> GetProductList(int pgStart, int pgLength, out int totalRecords, string searchValue, string sortBy)
        {
            dynamic result;
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@START", pgStart);
                param.Add("@LENGTH", pgLength);
                param.Add("@SEARCH", searchValue);
                param.Add("@SORT", sortBy);
                param.Add("@TOTALRECORDS", dbType: DbType.Int32, direction: ParameterDirection.Output);
                result = connection.Query<Product>("usp_GetProductMaster", param, commandType: CommandType.StoredProcedure).ToList();
                totalRecords = param.Get<int>("TOTALRECORDS");


            }

            return result;
        }

    }

}
