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
        
        //Produces = p.GetByAll();
        private ObservableCollection<ProductModel> _produces;
        private ObservableCollection<ProductPortfolio> _ProductPortfolio;




        private ProductModel _SelectecItems;
        private ProductPortfolio _SelectecPP;
        private string _ID_SelectecItems;
        private string _Name_SelectecItems;
        private int _id;
        private string _name;
       
        public ObservableCollection<ProductModel> Produces { get => _produces; set { _produces = value; OnPropertyChanged(nameof(Produces)); }  }
        public ObservableCollection<ProductPortfolio> ProductPortfolio { get => _ProductPortfolio; set { _ProductPortfolio = value; OnPropertyChanged(nameof(ProductPortfolio)); } }
        public ProductModel SelectecItems { get => _SelectecItems; set { _SelectecItems = value; OnPropertyChanged(nameof(SelectecItems)); } }
        public ProductPortfolio SelectecPP { get => _SelectecPP; set { _SelectecPP = value; OnPropertyChanged(nameof(SelectecPP));} }

        public string ID_SelectecItems { get => _ID_SelectecItems; set { _ID_SelectecItems = value; OnPropertyChanged(nameof(ID_SelectecItems)); } }
        public string Name_SelectecItems { get => _Name_SelectecItems; set { _Name_SelectecItems = value; OnPropertyChanged(nameof(Name_SelectecItems)); } }
        
        public int id { get => _id; set { _id = value; OnPropertyChanged(nameof(id));  }  }
        public string name { get => _name; set { _name = value; OnPropertyChanged(nameof(name)); } }

        //private ViewModelBase _currentChildView;



        public ICommand LoadData { get; set; }
        public ICommand ReLoad { get; set; }

        public ICommand AddProducts{get;set;}
        //public ICommand FindProducts{get;set;}
        public ICommand RemoveProducts { get;set;}
        public ICommand ModifyProducts { get;set;}


        public ICommand AddProductPortfolio { get; set; }
        public ICommand RemoveProductPortfolio { get; set; }
        public ICommand ModifyProductPortfolio { get; set; }

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

        private void ExecuteReLoad(object obj)
        {
            ProductRepository p = new ProductRepository();
            ProductPortfolio = p.GetByAllProductPortfolio();
        }
        private void ExecuteLoadData(object obj)
        {
            ProductRepository p = new ProductRepository(); 
            Produces = p.GetByAll(_SelectecPP.IdPP);
        }

        private bool CanExecuteLoadData(object obj)
        {
            if(SelectecPP == null)
                return false;
            return true;


        }

        private bool CanExecuteAddProducts(object obj)
        {
            return true;
        }

        public void ExecuteAddProducts(object obj)
        {
            
            AddProductsView addPD = new AddProductsView();
            addPD.Show();
            
        }

        private bool CanExecuteAddProductPortfolio(object obj)
        {
            return true;
        }

        public void ExecuteAddProductPortfolio(object obj)
        {

            AddProductPortfolioView a = new AddProductPortfolioView();
            a.Show();

        }

        private bool CanExecuteModifyProductPortfolio(object obj)
        {
            if(SelectecPP!= null)
                return true;
            return false;
        }

        public void ExecuteModifyProductPortfolio(object obj)
        {

            ModifyProductPortfolioView a = new ModifyProductPortfolioView(SelectecPP);
            a.Show();
            

        }

        private bool CanExecuteRemoveProductPortfolio(object obj)
        {
            if (SelectecPP == null)
                return false;
            return true;
        }

        public void ExecuteRemoveProductPortfolio(object obj)
        {

            ProductRepository repository = new ProductRepository();
            repository.RemovePP(SelectecPP.IdPP);
            MessageBox.Show("Đã xóa thành công");
            ProductPortfolio = repository.GetByAllProductPortfolio();
            Produces = null;
            
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
            MessageBox.Show("Đã xóa thành công");
            Produces = repository.GetByAll(SelectecItems.Id);

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
            ProductPortfolio = p.GetByAllProductPortfolio();

            LoadData = new ViewModelCommand(ExecuteLoadData, CanExecuteLoadData);
            AddProducts = new ViewModelCommand(ExecuteAddProducts, CanExecuteAddProducts);
            AddProductPortfolio = new ViewModelCommand(ExecuteAddProductPortfolio, CanExecuteAddProductPortfolio);
            ModifyProducts = new ViewModelCommand(ExecuteModifyProducts, CanExecuteModifyProducts);
            RemoveProducts = new ViewModelCommand(ExecuteRemoveProducts, CanExecuteRemoveProducts);
            RemoveProductPortfolio = new ViewModelCommand(ExecuteRemoveProductPortfolio, CanExecuteRemoveProductPortfolio);
            ReLoad = new ViewModelCommand(ExecuteReLoad);
            ModifyProductPortfolio = new ViewModelCommand(ExecuteModifyProductPortfolio, CanExecuteModifyProductPortfolio);

        }

        //public void loadData()
        //{
        //    ProductRepository p = new ProductRepository();
        //    produces = p.GetByAll();


        //}

   


   
    }
}
