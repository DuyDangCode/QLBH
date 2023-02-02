using QLBH.Models;
using QLBH.Repositories;
using QLBH.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace QLBH.Views
{
    /// <summary>
    /// Interaction logic for ModifyProductPortfolioView.xaml
    /// </summary>
    public partial class ModifyProductPortfolioView : Window
    {
        String id;
        public ICommand Modify { get; set; }
        public ICommand SelectImage { get; set; }
        private bool CanExecuteModify(object obj)
        {
            if (path.Text == null || unit.Text == null || name.Text == null)
                return false;
            return true;

        }

        public void ExecuteModify(object obj)
        {

            
            ProductPortfolio pd = new ProductPortfolio();
            pd.IdPP = id;
            pd.NamePP = name.Text;
            pd.Unit = unit.Text;
            pd.ImageLink = path.Text;

            ProductRepository repository = new ProductRepository();
            if(repository.ModifyPortfolio(pd))
                MessageBox.Show("Đã sửa thành công");
            else
                MessageBox.Show("Sửa thất bại!");





        }

        public void ExecuteSelectImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            path.Text = openFileDialog.FileName;
            
        }

        public ModifyProductPortfolioView()
        {
            InitializeComponent();

        }
        public ModifyProductPortfolioView(ProductPortfolio pdp)
        {
            InitializeComponent();
            id = pdp.IdPP;
            unit.ItemsSource = new List<string>() { "Cái", "Chai", "Lon", "Lít", "Kg" };
            path.Text = pdp.ImageLink;
            unit.Text = pdp.Unit;
            name.Text = pdp.NamePP;


            if (pdp.ImageLink.Length != 0) { image.Source = GetGlowingImage(pdp.ImageLink); }

            Modify = new ViewModelCommand(ExecuteModify, CanExecuteModify);
            modify.Command= Modify;

            SelectImage = new ViewModelCommand(ExecuteSelectImage);
            chooseImage.Command= SelectImage;
            
        public ImageSource GetGlowingImage(string _path)
        {
      
            
            BitmapImage glowIcon = new BitmapImage();


            glowIcon.BeginInit();
            glowIcon.UriSource = new Uri(_path);
            glowIcon.EndInit();

            return glowIcon;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ProfileUser pu = new ProfileUser();
            //pu.Show();
        }

        private void path_TextChanged(object sender, TextChangedEventArgs e)
        {
            image.Source = GetGlowingImage(path.Text);
        }
    }
}
