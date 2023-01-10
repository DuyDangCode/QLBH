using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QLBH.Models;
using QLBH.Views;
using QLBH.Repositories;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace QLBH.ViewModels
{
    public class StorageViewModel : ViewModelBase
    {
        private ObservableCollection<ProductModel> _produces;

        

        private ProductModel _SelectecItems;
        private string _ID_SelectecItems;
        private string _Name_SelectecItems;
        private int _id;
        private string _name;
       
        public ObservableCollection<ProductModel> Produces { get => _produces; set { _produces = value; OnPropertyChanged(nameof(Produces)); }  }
        public ProductModel SelectecItems { get => _SelectecItems; set { _SelectecItems = value; OnPropertyChanged(nameof(SelectecItems)); } }
        public string ID_SelectecItems { get => _ID_SelectecItems; set { _ID_SelectecItems = value; OnPropertyChanged(nameof(ID_SelectecItems)); } }
        public string Name_SelectecItems { get => _Name_SelectecItems; set { _Name_SelectecItems = value; OnPropertyChanged(nameof(Name_SelectecItems)); } }
        
        public int id { get => _id; set { _id = value; OnPropertyChanged(nameof(id));  }  }
        public string name { get => _name; set { _name = value; OnPropertyChanged(nameof(name)); } }

        //private ViewModelBase _currentChildView;

        public ICommand AddProducts{get;set;}
        public ICommand FindProducts{get;set;}
        public ICommand RemoveProducts { get;set;}
        public ICommand ModifyProducts { get;set;}

        //public ViewModelBase CurrentChildView
        //{
        //    get
        //    {
        //        return _currentChildView;
        //    }
        //    set
        //    {
        //        _currentChildView = value;
        //        OnPropertyChanged(nameof(CurrentChildView));
        //    }
        //}

        private bool CanExecuteAddProducts(object obj)
        {
            return true;
        }

        public void ExecuteAddProducts(object obj)
        {
            
            AddProductsView addPD = new AddProductsView();
            addPD.Show();
            
        }


        private bool CanExecuteRemoveProducts(object obj)
        {
            if (SelectecItems == null)
                return false;
            return true;
        }

        public void ExecuteRemoveProducts(object obj)
        {
            ProductRepository repository = new ProductRepository();
            repository.Remove(SelectecItems.Id);
            
            Produces = repository.GetByAll();
            //MessageBox.Show("Đã xóa thành công");
        }

        private bool CanExecuteModifyProducts(object obj)
        {
            if(SelectecItems != null)
                return true;
            return false;
        }

        public void ExecuteModifyProducts(object obj)
        {

            
            ModifyProductsViewModel mdfPD = new ModifyProductsViewModel();
            mdfPD.id = _SelectecItems.Id;
            mdfPD.name = _SelectecItems.Name;
            mdfPD.price = _SelectecItems.Price;


            mdfPD.Load();
        }



      

        public StorageViewModel()
        {
            ProductRepository p = new ProductRepository();
            Produces = p.GetByAll();

            AddProducts = new ViewModelCommand(ExecuteAddProducts, CanExecuteAddProducts);
            ModifyProducts = new ViewModelCommand(ExecuteModifyProducts, CanExecuteModifyProducts);
            RemoveProducts = new ViewModelCommand(ExecuteRemoveProducts, CanExecuteRemoveProducts);
            
            

        }

        //public void loadData()
        //{
        //    ProductRepository p = new ProductRepository();
        //    produces = p.GetByAll();


        //}

   


   
    }
}
