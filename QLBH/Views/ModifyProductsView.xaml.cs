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
using System.Windows.Shapes;
using QLBH.Models;
using QLBH.ViewModels;

namespace QLBH
{
    /// <summary>
    /// Interaction logic for ModifyProductsView.xaml
    /// </summary>
    public partial class ModifyProductsView : Window
    {
        //public string name2 { get; set; }
        //public string price2 { get; set; }

        //public ICommand Modify;
        public ModifyProductsView()
        {
            InitializeComponent();
            //ModifyProductsViewModel a = new ModifyProductsViewModel();
            //a.ProductIsChoosing = pd;
            //name2 = pd.Name;
            //price2 = Convert.ToString(pd.Price);

            //MessageBox.Show(name2);

        }

        public ModifyProductsView(string _id ,string _name, string _price, ICommand _modify)
        {
            InitializeComponent();

            id.Text = _id;
            price.Text = _price;
            name.Text = _name;
            
            Modify_btn.Command = _modify;
        }
    }
}
