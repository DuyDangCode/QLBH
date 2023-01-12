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
using QLBH.Models;


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
            //StorageViewModel a = new StorageViewModel();

            //string ImagePath = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\pd1.jpg";

            

            //listProduct.ItemsSource = a.produces;
            //FilterBy.ItemsSource = new string[] { "ID", "Tên sản phẩm", "Giá" };

            
            
        }

        //public Predicate<object> GetFilter()
        //{
        //    switch(FilterBy.SelectedItem as string)
        //    {
        //        case "ID":
        //            return IDFilter;
        //        case "Tên sản phẩm":
        //            return NameFilter;
                

        //    }

        //    return NameFilter;
        //}

        //private bool IDFilter(object obj) 
        //{
        //    var Filterobj = obj as ProductPortfolio ;
            
        //    return Filterobj.Id.Contains(FilterTextbox.Text,StringComparison.OrdinalIgnoreCase);
        //}


        //private bool NameFilter(object obj)
        //{
        //    var Filterobj = obj as ProductModel;

        //    return Filterobj.Name.Contains(FilterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        //}

       

        //private void FilterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if(FilterTextbox == null)
        //    {

        //        listProduct.Items.Filter = null;
        //    }
        //    else
        //    {
        //        listProduct.Items.Filter = GetFilter();

        //    }

        //}


        //private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    listProduct.Items.Filter = GetFilter();

        //}

        
    }
}
