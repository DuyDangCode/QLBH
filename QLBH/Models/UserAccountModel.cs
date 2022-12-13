using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class UserAccountModel
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string ProfilePicture { get; set; }
        
        //Role = 0 Admin
        //Role = 1 User
        public int Role { get; set; }
    }
}