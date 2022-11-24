using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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

        public void Add(ProductModel pd)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO dbo.PRODUCT VALUES (NEWID(), N'" + pd.Name + "', " + pd.Price + ", '2022-10-26 07:29:14', '2022-10-26 07:29:14', 0, 0, N'', N'', 0)";
                //MessageBox.Show("INSERT INTO dbo.PRODUCT ( ID_PRODUCT, NAME_PRODUCT, PRICE, EXPIRY, IMPORT_DATE, INITIAL_AMOUNT,C URRENT_AMOUNT, DESCRIPTION,IMAGE_PART) VALUES (   NEWID(), N'" + pd.Name + "', " + pd.Price + ", '2022-10-26 07:29:14', '2022-10-26 07:29:14', 0, 0, N'', N'')");
                command.ExecuteNonQuery();
                
            }
        }

        public void Modify(ProductModel pd)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.PRODUCT SET  NAME_PRODUCT = N'"+pd.Name+ "', PRICE = "+pd.Price+ " WHERE ID_PRODUCT = '"+pd.Id+"'";
                
                
                MessageBox.Show("UPDATE dbo.PRODUCT SET  NAME_PRODUCT = '" + pd.Name + "', PRICE = " + pd.Price + " WHERE ID_PRODUCT = '" + pd.Id + "'");
                command.ExecuteNonQuery();

            }
        }

        public void Remove(string id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.PRODUCT SET  STATE = 1 WHERE ID_PRODUCT = '" + id + "'";
                //MessageBox.Show("INSERT INTO dbo.PRODUCT ( ID_PRODUCT, NAME_PRODUCT, PRICE, EXPIRY, IMPORT_DATE, INITIAL_AMOUNT,C URRENT_AMOUNT, DESCRIPTION,IMAGE_PART) VALUES (   NEWID(), N'" + pd.Name + "', " + pd.Price + ", '2022-10-26 07:29:14', '2022-10-26 07:29:14', 0, 0, N'', N'')");
                command.ExecuteNonQuery();

            }
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
                command.CommandText = "select * from [Product] where STATE = 0";
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

        public List<ProductModel> Find(string id, string name)
        {
            List<ProductModel> products = new List<ProductModel>();


            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Product] where ID_PRODUCT = '" + id + "' or  NAME_PRODUCT = '" + name + "'";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
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
