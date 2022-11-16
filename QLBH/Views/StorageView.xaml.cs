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

using QLBH.ViewModels;

namespace QLBH
{
    /// <summary>
    /// Interaction logic for StorageView.xaml
    /// </summary>
    public partial class StorageView : UserControl
    {
        public StorageView()
        {
            InitializeComponent();
            StorageViewModel a = new StorageViewModel();
    
            string ImagePath = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\pd1.jpg";

   

            listProduct.ItemsSource = a.list;


        }

   

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            
        }
    }
}
