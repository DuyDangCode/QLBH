using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using QLBH.Repositories;

namespace QLBH.CustomControls.Chart
{
    public class YesterdayChartViewModel : ViewModelBase
    {
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public SeriesCollection SeriesCollection { get; set; }


        public YesterdayChartViewModel()
        {
            double[] a = new double[24];
            BillRepository billRepository = new BillRepository();
            a = billRepository.getDataOfYesterday();

            SeriesCollection = new SeriesCollection
            {


            };

            Labels = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"};


            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Danh thu ngày hôm qua.",
                Values = new ChartValues<double> { a[0] },
            });
            for (int i = 1; i < 24; i++)
            {
                SeriesCollection[0].Values.Add(a[i]);
            }



            YFormatter = value => value.ToString("C");

        }
    }
}
