using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using System.Data.SqlClient;
using System.Data;

namespace QLBH.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser=true;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }

            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
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
                command.CommandText = "select * from [User]";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        UserModel user = new UserModel();
                        user.Id = Convert.ToString(SqlReader["ID"]);
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

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
