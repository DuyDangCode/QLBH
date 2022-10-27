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
            //List<string> l = new List<string>();

            //l.Add(a.produces[0].Name);
            //l.Add(a.produces[1].Name);

            //List<string> r = new List<string>();
            //r.Add("xxx");
            //r.Add("yyy");
            string ImagePath = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\pd1.jpg";

            string num = "aaaaaaaaaaaaaaaa";

            //listProduct.ItemsSource = a.list;
            listProduct.ItemsSource = num;


        }

        public class Path
        {
            string Name = "Hoa Hong";
            string ImagePath = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\pd1.jpg";
            string Price = "200";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            
        }
    }
}
