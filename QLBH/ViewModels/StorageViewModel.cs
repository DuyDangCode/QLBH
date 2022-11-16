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

namespace QLBH.ViewModels
{
    public class StorageViewModel : ViewModelBase
    {
        public List<ProductModel> produces;
        public List<pd> list = new List<pd>();
        private pd _SelectecItems;
        private string _ID_SelectecItems;
        private string _Name_SelectecItems;
       
        public pd SelectecItems { get => _SelectecItems; set { _SelectecItems = value; OnPropertyChanged(nameof(SelectecItems)); if (SelectecItems != null) { ID_SelectecItems = SelectecItems.Id; Name_SelectecItems = SelectecItems.Name; } } }
        public string ID_SelectecItems { get => _ID_SelectecItems; set { _ID_SelectecItems = value; OnPropertyChanged(nameof(ID_SelectecItems)); } }
        public string Name_SelectecItems { get => _Name_SelectecItems; set { _Name_SelectecItems = value; OnPropertyChanged(nameof(Name_SelectecItems)); } }
        private ViewModelBase _currentChildView;

        public ICommand AddProducts{get;set;}
        public ICommand DeleteProducts { get;set;}
        public ICommand EditProducts { get;set;}

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
            AddProductsView a = new AddProductsView();
            
            a.Show();
        }


        private bool CanExecuteDeleteProducts(object obj)
        {
            if (SelectecItems == null)
                return false;
            return true;
        }

        public void ExecuteDeleteProducts(object obj)
        {
          
        }

        private bool CanExecuteEditProducts(object obj)
        {
            return true;
        }

        public void ExecuteEditProducts(object obj)
        {
            ;
        }
        public StorageViewModel()
        {
            ProductRepository p = new ProductRepository();
            produces = p.GetByAll();

            for (int i = 0; i < produces.Count; i++)
            {
                //pd a = new pd(produces[i].Name);
                list.Add(new pd() { Id = produces[i].Id, Name = produces[i].Name, Price = Convert.ToString(produces[i].Price), ImagePath = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\pd1.jpg" });


            }

            AddProducts = new ViewModelCommand(ExecuteAddProducts, CanExecuteAddProducts);

            

            

        }


        public class pd
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string ImagePath { get; set; }


        }


   
    }
}
