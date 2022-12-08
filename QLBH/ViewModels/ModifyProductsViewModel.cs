using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QLBH.Repositories;
using System.Windows.Input;
using System.Windows.Forms;
using QLBH.Models;

namespace QLBH.ViewModels
{
    public class ModifyProductsViewModel : ViewModelBase
    {
        

        //public static ModifyProductsViewModel instance;
        public ProductModel ProductIsChoosing { get; set; }

        private string _name;
        private int _amount;
        private long _price;
        private string _inputTime;
        private DateTime _expiryTime;
        private string _supply;
        private string _id;

        public string name { get => _name; set { _name = value; OnPropertyChanged(nameof(name)); } }
        public long price { get => _price; set { _price = value; OnPropertyChanged(nameof(price)); } }
        public string id { get => _id; set { _id = value; OnPropertyChanged(nameof(id)); } }

        

        public void Load()
        {
            ModifyProductsView modifyProductsView = new ModifyProductsView(id,name,Convert.ToString(price));
            modifyProductsView.Show();

            name = modifyProductsView.name.Text;
            price = Convert.ToInt64(modifyProductsView.price.Text);
        }

        public ModifyProductsViewModel()
        {
            
            

            
            
           
            
        }

    }
}
