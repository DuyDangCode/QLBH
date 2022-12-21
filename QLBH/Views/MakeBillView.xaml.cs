using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLBH.ViewModels;
using QLBH.Repositories;

namespace QLBH
{
    /// <summary>
    /// Interaction logic for MakeBillView.xaml
    /// </summary>
    public partial class MakeBillView : UserControl
    {
        public MakeBillView()
        {
            InitializeComponent();
           

        }

        //private void namesCbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ProductRepository pd = new ProductRepository();
        //    //priceTb.Text = pd.GetPriceByName(namesCbb.Text).ToString();
        //    //priceTb.Text = namesCbb.Text;

        //}
    }
}
