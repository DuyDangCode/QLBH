using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Repositories;
using QLBH.Models;
using System.Windows.Input;
using System.Windows.Forms;

namespace QLBH.ViewModels
{
    
    public class UserManagementViewModel: ViewModelBase
    {
        private List<UserModel> _users;
        private string _id;
        private UserModel _selectedUser;


        public ICommand AddUser { get; set; }

        public ICommand RemoveUser { get; set; }

        public List<UserModel> Users {get=> _users; set { _users = value; OnPropertyChanged(nameof(Users)); }  }

        public string UserId { get => _id; set { _id = value; OnPropertyChanged(nameof(UserId)); }  }

        public UserModel SelectedUser {get => _selectedUser; set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser));}}

        private bool CanExecuteAddUser(object obj)
        {
            return true;

        }

        private void ExecuteAddUser(object obj)
        {
            AddUserView addUserView = new AddUserView();
            addUserView.Show();

        }

        private bool CanExecuteRemoveUser(object obj)
        {
            if(SelectedUser == null)
                return false;
            return true;

        }

        private void ExecuteRemoveUser(object obj)
        {
            UserRepository repository = new UserRepository();
            
            repository.Remove(SelectedUser.Id);
            MessageBox.Show("Đã xóa thành công");

        }



        public UserManagementViewModel()
        {
            UserRepository u = new UserRepository();
            Users = u.GetByAll();
            AddUser = new ViewModelCommand(ExecuteAddUser, CanExecuteAddUser);
            RemoveUser = new ViewModelCommand(ExecuteRemoveUser, CanExecuteRemoveUser);

        }
    }
}
