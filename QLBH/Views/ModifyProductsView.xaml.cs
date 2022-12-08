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
using QLBH.Repositories;

namespace QLBH
{
    /// <summary>
    /// Interaction logic for ModifyProductsView.xaml
    /// </summary>
    public partial class ModifyProductsView : Window
    {
        //public string name2 { get; set; }
        //public string price2 { get; set; }
        private string idd;

        public ICommand Modify { get; set; }
        private bool CanExecuteModifyProducts(object obj)
        {

            return true;

        }

        public void ExecuteModifyProducts(object obj)
        {

            if (name.Text == null)
                MessageBox.Show("Tên sản phẩm không được để trống!");
            if (Convert.ToInt64(price.Text) == 0)
                MessageBox.Show("Giá sản phẩn không được để trống!");
            else
            {
                ProductModel pd = new ProductModel();
                pd.Id = idd;
                pd.Name = name.Text;
                pd.Price = Convert.ToInt64(price.Text);
                ProductRepository repository = new ProductRepository();
                repository.Modify(pd);
                MessageBox.Show("Đã sửa thành công");




            }
        }
        public ModifyProductsView()
        {
            InitializeComponent();
            Modify = new ViewModelCommand(ExecuteModifyProducts, CanExecuteModifyProducts);
            //ModifyProductsViewModel a = new ModifyProductsViewModel();
            //a.ProductIsChoosing = pd;
            //name2 = pd.Name;
            //price2 = Convert.ToString(pd.Price);

            //MessageBox.Show(name2);

        }

        public ModifyProductsView(string _id ,string _name, string _price)
        {
            InitializeComponent();
            Modify = new ViewModelCommand(ExecuteModifyProducts, CanExecuteModifyProducts);

            id.Text = _id;
            price.Text = _price;
            name.Text = _name;
            idd = _id; 

            Modify_btn.Command = Modify;
        }
    }
}
