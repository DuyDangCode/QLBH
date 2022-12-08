using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public interface IUserRepository
    {
        UserModel getCurrentUser(); 
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Modify(UserModel userModel);
        void Remove(string id);
        UserModel GetById(string id);
        UserModel GetByUsername(string username);
        List<UserModel> GetByAll();
        //...
    }
}
