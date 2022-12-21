using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Repositories;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;

using System.Collections.ObjectModel;



namespace QLBH.ViewModels
{
    public class MakeBillViewModel : ViewModelBase
    {
        private List<string> _namePds;
        private double _price;
        private string _nameCurrentUser;
        private string _date;
        private ObservableCollection<pdInBill> _listPD;
        //ObservableCollection<pdInBill> listPD = new ObservableCollection<pdInBill>();

        public class pdInBill
        {
            public string id_pdInBill;
            public string name_pdInBill;
            public string amount_pdInBill;
            public double price_pdInBill;
        }



        public List<string> NamePds { get { return _namePds; } set { _namePds = value; OnPropertyChanged(nameof(NamePds)); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }

        public string NameCurrentUser { get { return _nameCurrentUser; } set { _nameCurrentUser = value; OnPropertyChanged(nameof(NameCurrentUser)); } }
        public string Date { get { return _date; } set { _date = value; OnPropertyChanged(nameof(Date)); } }
        public ObservableCollection<pdInBill> listPD { get { return _listPD; } set { _listPD = value; OnPropertyChanged(nameof(listPD)); } }

        public ICommand Add { get; set; }
        public ICommand Delete { get; set; }

        private bool CanExecuteAdd(object obj)
        {

            return true;
        }

        public void ExecuteAdd(object obj)
        {
            pdInBill a = new pdInBill();


            a.id_pdInBill = "0";
            a.name_pdInBill = "a";
            a.amount_pdInBill = "b";
            a.price_pdInBill = Price;
            listPD.Add(a);
            MessageBox.Show(a.price_pdInBill.ToString());


        }
        private void getNameCurrentUser()
        {
            UserRepository userRepository = new UserRepository();
            NameCurrentUser = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name).Username;
        }
        public MakeBillViewModel()
        {
            ProductRepository pd = new ProductRepository();
            
            NamePds = pd.getNameAll();
            Price = pd.GetPriceByName(NamePds[0]);
            
            Date = DateTime.Now.ToString();
            NameCurrentUser = "Thanh Duy";
            Add = new ViewModelCommand(ExecuteAdd, CanExecuteAdd);
            listPD = new ObservableCollection<pdInBill>();
        }


    }
}
