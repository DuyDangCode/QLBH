using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class pdInBill
    {

        public string id_pdInBill { get; set; }
        public string name_pdInBill { get; set; }

        public int amount_pdInBill { get; set; }
        public double price_pdInBill { get; set; }

        public double discount_pdInBill { get; set; }


        public void import(string id, string name, int amount, double price, double discount)
        {
            id_pdInBill = id;
            name_pdInBill = name;
            amount_pdInBill = amount;
            price_pdInBill = price;
            discount_pdInBill = discount;
        }
    }
}
