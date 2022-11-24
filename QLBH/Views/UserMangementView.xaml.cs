using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLBH.Models;
using QLBH.ViewModels;  

namespace QLBH
{
    /// <summary>
    /// Interaction logic for UserMangementView.xaml
    /// </summary>
    public partial class UserMangementView : UserControl
    {
        public UserMangementView()
        {
            InitializeComponent();
            //StorageViewModel a = new StorageViewModel();
            UserManagementViewModel userManagementViewModel = new UserManagementViewModel();

            //string ImagePath = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\pd1.jpg";



            listProduct.ItemsSource = userManagementViewModel.Users;
            FilterBy.ItemsSource = new string[] { "ID", "Tên tài khoản "};
        }

     

        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "ID":
                    return IDFilter;
                case "Tên tài khoản":
                    return UserNameFilter;


            }

            return UserNameFilter;
        }

        private bool IDFilter(object obj)
        {
            var Filterobj = obj as UserModel;

            return Filterobj.Id.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }


        private bool UserNameFilter(object obj)
        {
            var Filterobj = obj as UserModel;

            return Filterobj.Username.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }



        private void FilterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FilterTextbox == null)
            {

                listProduct.Items.Filter = null;
            }
            else
            {
                listProduct.Items.Filter = GetFilter();

            }

        }


        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            listProduct.Items.Filter = GetFilter();

        }
    }
}
