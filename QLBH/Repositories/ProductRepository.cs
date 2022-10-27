using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace QLBH.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }
        public ProductModel GetProductByName(string name) 
        {
            throw new NotImplementedException();

        }

        public void Add(ProductModel product)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "";
                
            }
        }

        public void Edit(ProductModel product)
        {

        }

        public void Remove(int id)
        {

        }

        public List<ProductModel> GetByAll() 
        {
            List<ProductModel> products = new List<ProductModel>();
            

            using (var connection = GetConnection())
            using(SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Product]";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader() ;
                if(SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        ProductModel pd = new ProductModel();
                        pd.Id = Convert.ToString(SqlReader["ID_PRODUCT"]);
                        pd.Name = Convert.ToString(SqlReader["NAME_PRODUCT"]);
                        pd.Price = Convert.ToInt64(SqlReader["PRICE"]);

                        products.Add(pd);
                    }

                }
                else
                {


                }
            }

            return products;
        }
    }
}
