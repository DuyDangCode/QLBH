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
    public class LastMonthChartViewModel:ViewModelBase
    {
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public LastMonthChartViewModel()
        {

            double[] a = new double[31];
            BillRepository billRepository = new BillRepository();
            a = billRepository.getDataOfLastMonth();

            SeriesCollection = new SeriesCollection
            {


            };



            int m = DateTime.Now.Month;
            if(m == 1)
            {
                m = 12;
            }
            else
            {
                m--;
            }

            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
            {
                Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };

                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Danh thu tháng này.",
                    Values = new ChartValues<double> { a[0] },
                });
                for (int i = 1; i < 31; i++)
                {
                    SeriesCollection[0].Values.Add(a[i]);
                }
            }
            else if (m == 2)
            {
                int y = DateTime.Now.Year;
                if (y % 4 == 0)
                {
                    Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29" };
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Danh thu tháng này.",
                        Values = new ChartValues<double> { a[0] },
                    });
                    for (int i = 1; i < 29; i++)
                    {
                        SeriesCollection[0].Values.Add(a[i]);
                    }
                }
                else
                {
                    Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };
                    SeriesCollection.Add(new ColumnSeries
                    {
                        Title = "Danh thu tháng này.",
                        Values = new ChartValues<double> { a[0] },
                    });
                    for (int i = 1; i < 28; i++)
                    {
                        SeriesCollection[0].Values.Add(a[i]);
                    }
                }
            }
            else
            {
                Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Danh thu tháng này.",
                    Values = new ChartValues<double> { a[0] },
                });
                for (int i = 1; i < 30; i++)
                {
                    SeriesCollection[0].Values.Add(a[i]);
                }
            }



            YFormatter = value => value.ToString("C");

        
        }
    }
}
