using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Repositories;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using QLBH.Models;

using System.Collections.ObjectModel;



namespace QLBH.ViewModels
{
    public class MakeBillViewModel : ViewModelBase
    {
        ProductRepository pd = new ProductRepository();
        private List<string> _namePds;
        private double _price;
        private string _nameCurrentUser;
        private string _idCurrentUser;
        private string _date;
        private ObservableCollection<pdInBill> _listPD;
        private pdInBill _selectedItems;
        private double _billPrice = 0;
        private double _discount;
        private string _name;
        private int _amount;


        



        public List<string> NamePds { get { return _namePds; } set { _namePds = value; OnPropertyChanged(nameof(NamePds)); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }

        public string NameCurrentUser { get { return _nameCurrentUser; } set { _nameCurrentUser = value; OnPropertyChanged(nameof(NameCurrentUser)); } }
        public string Date { get { return _date; } set { _date = value; OnPropertyChanged(nameof(Date)); } }
        public ObservableCollection<pdInBill> ListPD { get { return _listPD; } set { _listPD = value; OnPropertyChanged(nameof(ListPD)); } }

        public pdInBill SelectecItems { get { return _selectedItems; } set { _selectedItems = value; OnPropertyChanged(nameof(SelectecItems)); } }

        public double BillPrice { get { return _billPrice; } set { _billPrice = value; OnPropertyChanged(nameof(BillPrice)); } }

        public double Discount { get { return _discount; } set { _discount = value; OnPropertyChanged(nameof(Discount));} }
       
        public string Name { get { return _name; } set {Price = pd.GetPriceByName(value); _name = value; OnPropertyChanged(nameof(Name));} }
        public int Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(nameof(Amount));} }
        public ICommand Add { get; set ; }
        public ICommand Delete { get; set; }
        public ICommand Payment { get; set; }

        //public void namePdSelectionChanged()
        //{
        //    ProductRepository productRepository = new ProductRepository();
        //    Price = productRepository.GetPriceByName(Name);
        //}

        private bool CanExecuteAdd(object obj)
        {
            if (Amount != 0)
                return true;
            return false;
        }

        public void ExecuteAdd(object obj)
        {
            pdInBill a = new pdInBill();
            
            
            
            a.import(pd.GetIdByName(Name),Name,Amount,Price, Discount);
            ListPD.Add(a);
            
            BillPrice += a.amount_pdInBill * a.price_pdInBill - a.amount_pdInBill * a.price_pdInBill * a.discount_pdInBill * 0.01;






        }

        private bool CanExecutePayment(object obj)
        {
            if (_listPD.Count() != 0)
                return true;
            return false;
        }

        public void ExecutePayment(object obj)
        {
            
            BillRepository billRepository = new BillRepository();
            if (billRepository.payment(_listPD, _idCurrentUser, Price))
            {
                MessageBox.Show("Bạn co muốn in hóa đơn không?");

            }
            else
            {
                MessageBox.Show("Thanh toán thất bại.");
            }

            ListPD = new ObservableCollection<pdInBill>();
            BillPrice = 0;


        }

        private bool CanExecuteDelete(object obj)
        {
            if(SelectecItems != null)
                return true;
            return false;
        }

        public void ExecuteDelete(object obj)
        {
            BillPrice -= SelectecItems.amount_pdInBill * SelectecItems.price_pdInBill - SelectecItems.amount_pdInBill * SelectecItems.price_pdInBill * SelectecItems.discount_pdInBill * 0.01;
            ListPD.Remove(SelectecItems);
            

        }
        private void getNameCurrentUser()
        {
            UserRepository userRepository = new UserRepository();
            NameCurrentUser = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name).Username;
            _idCurrentUser = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name).Id;
        }
        public MakeBillViewModel()
        {
           

            
            NamePds = pd.getNameAll();
            if(NamePds.Count != 0)
                Price = pd.GetPriceByName(NamePds[0]);
            else
            {
                Price = 0;
            }
            
            Date = DateTime.Now.ToString();
            getNameCurrentUser();
            Add = new ViewModelCommand(ExecuteAdd, CanExecuteAdd);
            Delete = new ViewModelCommand(ExecuteDelete, CanExecuteDelete);
            Payment = new ViewModelCommand(ExecutePayment, CanExecutePayment);

            ListPD = new ObservableCollection<pdInBill>();
            Discount = 0;
            Amount = 1;
            
            
            
           
        }


    }
}
