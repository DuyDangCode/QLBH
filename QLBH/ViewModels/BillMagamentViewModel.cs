using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QLBH.Models;
using QLBH.Repositories;
namespace QLBH.ViewModels
{
    public class BillMagamentViewModel:ViewModelBase 
    {
        BillRepository billRepository = new BillRepository();
        private ObservableCollection<BillModel> _bill;



        public ObservableCollection<BillModel> Bill { get { return _bill; } set { _bill = value; OnPropertyChanged(nameof(Bill)); } }

        public BillMagamentViewModel()
        {
            Bill = billRepository.getAllBill();
        }
    }
}
