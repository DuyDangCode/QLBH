using System;
using FontAwesome.Sharp;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using QLBH.Models;
using QLBH.Repositories;


namespace QLBH.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        UserModel _user;
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _profileImg;
        //private string _caption;
        //private IconChar _icon;
        private IUserRepository userRepository;

        public string profileImg { get { return _profileImg; } set { _profileImg = value; OnPropertyChanged(nameof(profileImg)); } }

        //Properties
        //public UserAccountModel CurrentUserAccount
        //{
        //    get
        //    {
        //        return _currentUserAccount;
        //    }
        //    set
        //    {
        //        _currentUserAccount = value;
        //        OnPropertyChanged(nameof(CurrentUserAccount));
        //    }
        //}
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        //public string Caption
        //{
        //    get
        //    {
        //        return _caption;
        //    }
        //    set
        //    {
        //        _caption = value;
        //        OnPropertyChanged(nameof(Caption));
        //    }
        //}
        //public IconChar Icon
        //{
        //    get
        //    {
        //        return _icon;
        //    }
        //    set
        //    {
        //        _icon = value;
        //        OnPropertyChanged(nameof(Icon));
        //    }
        //}
        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }

        public ICommand ShowStorageViewCommand { get; }
        public ICommand ShowUserMangementViewCommand { get; }

        public ICommand ShowBillManagementViewCommand { get; }
        public ICommand ShowMakeBillViewCommand { get; }
        public ICommand ShowSettingViewCommand { get; }


        public MainViewModel()
        {
            userRepository = new UserRepository();
            //CurrentUserAccount = new UserAccountModel();
            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowStorageViewCommand = new ViewModelCommand(ExecuteShowStorageViewCommand);
            ShowUserMangementViewCommand = new ViewModelCommand(ExecuteShowUserMangementViewCommand);
            ShowBillManagementViewCommand= new ViewModelCommand(ExecuteShowBillManagementViewCommand);
            ShowMakeBillViewCommand = new ViewModelCommand(ExecuteShowMakeBillViewCommand);
            ShowSettingViewCommand = new ViewModelCommand(ExecuteShowSettingViewCommand);

            //_user = userRepository.getCurrentUser();
            //profileImg = _user.profileImage;
            
            //Default view
            ExecuteShowHomeViewCommand(null);
            //LoadCurrentUserData();
        }
        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            //Caption = "Customers";
            //Icon = IconChar.UserGroup;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            //Caption = "Dashboard";
            //Icon = IconChar.Home;
        }

        private void ExecuteShowStorageViewCommand(object obj)
        {
            CurrentChildView = new StorageViewModel();
            //Caption = "Dashboard";
            //Icon = IconChar.Home;
        }

        private void ExecuteShowUserMangementViewCommand(object obj)
        {
            CurrentChildView = new UserManagementViewModel();


        }

        private void ExecuteShowBillManagementViewCommand(object obj)
        {
            CurrentChildView = new BillMagamentViewModel();


        }

        private void ExecuteShowMakeBillViewCommand(object obj)
        {
            CurrentChildView = new MakeBillViewModel();
            //Caption = "Customers";
            //Icon = IconChar.UserGroup;
        }

        private void ExecuteShowSettingViewCommand(object obj)
        {
            CurrentChildView = new SettingViewModel();
            //Caption = "Customers";
            //Icon = IconChar.UserGroup;
        }

        //private void LoadCurrentUserData()
        //{
        //    var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
        //    if (user != null)
        //    {
        //        CurrentUserAccount.Username = user.Username;
        //        CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
        //        CurrentUserAccount.ProfilePicture = null;
        //    }
        //    else
        //    {
        //        CurrentUserAccount.DisplayName = "Invalid user, not logged in";
        //        //Hide child views.
        //    }
        //}
    }
}

