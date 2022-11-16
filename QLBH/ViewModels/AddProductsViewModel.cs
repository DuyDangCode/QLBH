using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.Models;
using QLBH.Repositories;
using System.Windows.Input;

namespace QLBH.ViewModels
{
    public class AddProductsViewModel : ViewModelBase
    {
        public ICommand Add { get; set; }
        private string _name;
        private int _amount;
        private long _price;
        private string _inputTime;
        private DateTime _expiryTime;
        private string _supply;
        public string name { get=>_name; set { _name = value; OnPropertyChanged(nameof(name)); } }
   
        private bool CanExecuteAddProducts(object obj)
        {
            
            return true;
        }

        public void ExecuteAddProducts(object obj)
        {

            if (name == null)
                MessageBox.Show("Vui lòng điền tên sản phẩm");
            else MessageBox.Show(name);
        }


        public AddProductsViewModel()
        {
           

            Add = new ViewModelCommand(ExecuteAddProducts, CanExecuteAddProducts);
        }
        


    }
}
