using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Repositories;
using QLBH.Models;

namespace QLBH.ViewModels
{
    
    public class UserManagementViewModel: ViewModelBase
    {
        public List<UserModel> Users;

        public UserManagementViewModel()
        {
            UserRepository u = new UserRepository();
            Users = u.GetByAll();


        }
    }
}
