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
using System.Collections.ObjectModel;

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

        public ObservableCollection<ProductModel> GetByAll() 
        {
            ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();
            

            using (var connection = GetConnection())
            using(SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Product] join PRODUCT_TYPE ON PRODUCT_TYPE.ID_PRODUCT_TYPE = PRODUCT.ID_PRODUCT_TYPE JOIN dbo.SUPPLY ON SUPPLY.ID_SUPPLY = PRODUCT.ID_SUPPLY where PRODUCT.ISDELETE = 0 order by EXPIRY";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader() ;
                if(SqlReader.HasRows)
                {
                    int i = 1;
                    while (SqlReader.Read())
                    {
                        ProductModel pd = new ProductModel();
                        pd.Id = Convert.ToString(SqlReader["ID"]);
                        pd.Name = Convert.ToString(SqlReader["NAME_PRODUCT"]);
                        pd.Price = Convert.ToInt64(SqlReader["PRICE"]);
                        pd.Import_Price = Convert.ToInt64(SqlReader["IMPORT_PRICE"]);
                        pd.Number = i;
                        i++;
                        pd.Amount = Convert.ToInt32(SqlReader["AMOUNT"]);
                        pd.ImagePath = Convert.ToString(SqlReader["IMAGE_PRODUCT"]);
                        pd.Description = Convert.ToString(SqlReader["Description"]);
                        pd.Import_Date = Convert.ToString(SqlReader["IMPORT_DATE"]);
                        pd.Expiry = Convert.ToString(SqlReader["EXPIRY"]);
                        pd.Supply = Convert.ToString(SqlReader["NAME_SUPPLY"]);

                        products.Add(pd);
                        
                    }

                }
                else
                {


                }
            }

            return products;
        }

        public List<string> getNameAll()
        {
            List<String> namesPd =  new List<string>();
            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select NAME_PRODUCT from [PRODUCT_TYPE] where ISDELETE = 0";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        

                        namesPd.Add(Convert.ToString(SqlReader["NAME_PRODUCT"]));
                    }

                }
                else
                {


                }
            }


            return namesPd;

        }

        public double GetPriceByName(string name)
        {
            double price = 0;

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select PRICE from [Product] join PRODUCT_TYPE ON PRODUCT_TYPE.ID_PRODUCT_TYPE = PRODUCT.ID_PRODUCT_TYPE where PRODUCT_TYPE.ISDELETE = 0 and NAME_PRODUCT = N'" + name+"'";

                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {


                        price = Convert.ToDouble(SqlReader["PRICE"]);
                    }

                }

            }


            return price;


        }
        public string GetIdByName(string name)
        {
            string id = null;

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select ID_PRODUCT_TYPE from [PRODUCT_TYPE] where isdelete = 0 and NAME_PRODUCT = N'" + name + "'";

                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {


                        id = Convert.ToString(SqlReader["ID_PRODUCT"]);
                    }

                }

            }


            return id;


        }
    }

}
