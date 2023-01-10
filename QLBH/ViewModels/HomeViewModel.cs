using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using QLBH.Repositories;
using System.Windows.Input;
using QLBH.CustomControls.Chart;

namespace QLBH.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private string _numberOfOrders;
        private string _revOfDay;

        private ViewModelBase _currentChart;

        private DateTime _dateIschoosing;




        public string NumOfOrders { get  { return _numberOfOrders; } set { _numberOfOrders = value; OnPropertyChanged(nameof(NumOfOrders)); } }
        public string RevOfDay { get { return _revOfDay; } set { _revOfDay = value; OnPropertyChanged(nameof(RevOfDay)); } }

        public ViewModelBase CurrentChart { get { return _currentChart; } set { _currentChart = value; OnPropertyChanged(nameof(CurrentChart)); } }
        public DateTime DateIschoosing { get { return _dateIschoosing; } set { _dateIschoosing = value; ExecuteShowDayChart(null);  OnPropertyChanged(nameof(DateIschoosing)); } }


        public ICommand ShowYesterdayChart { get; }
        public ICommand ShowMonthChart { get; }
        public ICommand ShowLastMonthChart { get; }
        public ICommand ShowDayChart { get; }

        public HomeViewModel()
        {

            BillRepository billRepository = new BillRepository();

            

            NumOfOrders = billRepository.getNumOfOrders().ToString();
            RevOfDay = billRepository.getRevOfDay().ToString();
            //modifying the series collection will animate and update the chart
            //SeriesCollection.Add(new LineSeries
            //{
            //    Title = "Series 4",
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = Brushes.Gray
            //});

            ////modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            ShowYesterdayChart = new ViewModelCommand(ExecuteShowYesterdayChart);
            ShowMonthChart = new ViewModelCommand(ExecuteShowMonthChartCommand);
            //ShowLastMonthChart = new ViewModelCommand(ExecuteShowLastMonthChart);
            
            ShowLastMonthChart = new ViewModelCommand(ExecuteShowDayChart);
            ExecuteShowYesterdayChart(null);

        }

        private void ExecuteShowYesterdayChart(object obj)
        {
            CurrentChart = new YesterdayChartViewModel();
            
        }
        private void ExecuteShowMonthChartCommand(object obj)
        {
            CurrentChart = new MonthChartViewModel();

        }
        private void ExecuteShowLastMonthChart(object obj)
        {
            CurrentChart = new LastMonthChartViewModel();

        }

        private void ExecuteShowDayChart(object obj)
        {
            CurrentChart = new DayChartViewModel(DateIschoosing.ToString("yyyy-MM-dd"));

        }
    }
}
