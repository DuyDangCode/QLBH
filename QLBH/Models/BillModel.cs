using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class BillModel
    {
        public string idBill { get; set; }
        public string dateBill { get; set; }
        public string nameUser { get; set; }
        public double orderValue { get; set; }
        public double discount { get; set; }
    }
}
