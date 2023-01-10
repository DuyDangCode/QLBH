using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using System.Collections.ObjectModel;

namespace QLBH.Models
{
    public interface IBillRepository
    {
        public double getRevOfDay();
        public double getNumOfOrders();
        public double[] getDataOfYesterday();
        public double[] getDataOfThisMonth();
        public double[] getDataOfLastMonth();
        public double[] getDataOnDay(string day);
        public ObservableCollection<BillModel> getAllBill();

        public bool payment(ObservableCollection<pdInBill> _listPD, string idUser, double price);
        

    }
}
