using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLBH.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
       
        public UserModel currentUser = new UserModel();

     

        public UserModel getCurrentUser()
        {
            
            return currentUser;

        }

        public void Add(UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO dbo.[USER] VALUES (NEWID(),N'"+user.Username+"',N'"+user.Password+"',N'"+user.Name+"',N'"+user.LastName+"',N'"+user.Email+"',0,"+user.Role+")";
                //MessageBox.Show("INSERT INTO dbo.PRODUCT ( ID_PRODUCT, NAME_PRODUCT, PRICE, EXPIRY, IMPORT_DATE, INITIAL_AMOUNT,C URRENT_AMOUNT, DESCRIPTION,IMAGE_PART) VALUES (   NEWID(), N'" + pd.Name + "', " + pd.Price + ", '2022-10-26 07:29:14', '2022-10-26 07:29:14', 0, 0, N'', N'')");
                command.ExecuteNonQuery();

            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser=true;
            SqlDataReader data;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username and [password]=@password and state = 0";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
                //data = command.ExecuteReader();
                //var temp = data.Read();
                //if (temp)
                //{
                //    currentUser.Id = data["ID_USER"].ToString();


                //    currentUser.Username = data["USERNAME"].ToString();
                //    currentUser.Name = data["NAME"].ToString();
                //    currentUser.LastName = data["LASTNAME"].ToString();
                //    currentUser.Email = data["EMAIL"].ToString();
                //    // role = 0 => admin
                //    // role = 1 => user
                //    currentUser.Role = Convert.ToInt32(data["ROLE"]);
                //    currentUser.profileImage = data["PROFILE_IMAGE"].ToString();
                    
                //    currentUser.cicNumber = data["CIC_NUMBER"].ToString();
                //}
            }
            
            return validUser;
        }

        public void Modify(UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE dbo.[USER] SET ";
                //MessageBox.Show("INSERT INTO dbo.PRODUCT ( ID_PRODUCT, NAME_PRODUCT, PRICE, EXPIRY, IMPORT_DATE, INITIAL_AMOUNT,C URRENT_AMOUNT, DESCRIPTION,IMAGE_PART) VALUES (   NEWID(), N'" + pd.Name + "', " + pd.Price + ", '2022-10-26 07:29:14', '2022-10-26 07:29:14', 0, 0, N'', N'')");
                command.ExecuteNonQuery();

            }
        }

        public List<UserModel> GetByAll()
        {
            List<UserModel> users = new List<UserModel>();


            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where state = 0";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        UserModel user = new UserModel();
                        user.Id = Convert.ToString(SqlReader["ID_USER"]);
                        user.Username = Convert.ToString(SqlReader["USERNAME"]);
                        user.Password = Convert.ToString(SqlReader["PASSWORD"]);

                        users.Add(user);
                    }

                }
                else
                {


                }
            }

            return users;
        }

        public UserModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            SqlDataReader data;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username and state = 0";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader["ID_USER"].ToString(),
                            Username = reader["USERNAME"].ToString(),
                            Name = reader["Name"].ToString(),
                            LastName = String.Empty,
                            Email = String.Empty,
                            profileImage = reader["PROFILE_IMAGE"].ToString(),
                            Role = Convert.ToInt32(reader["ROLE"]),

                    };
                    }
                }
                
               
            }

            return user;
        }

        public void Remove(string id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [USER] SET STATE = 1 WHERE ID_USER = '"+id+"'";
                //MessageBox.Show("UPDATE [USER] SET SATE = 1 WHERE ID = '" + id + "'");
                command.ExecuteNonQuery();

            }
        }
    }
}
