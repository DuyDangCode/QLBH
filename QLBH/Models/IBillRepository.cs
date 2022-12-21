using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public interface IBillRepository
    {
        public double getRevOfDay();
        public double getNumOfOrders();
        public double[] getDataOfYesterday();
        public double[] getDataOfThisMonth();
        public double[] getDataOfLastMonth();

    }
}
