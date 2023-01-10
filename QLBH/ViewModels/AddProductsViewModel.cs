using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.Models;
using QLBH.Repositories;
using System.Windows.Input;

namespace QLBH.ViewModels
{
    public class AddProductsViewModel : ViewModelBase
    {
        public ICommand Add { get; set; }

        public string _idPd;
        private List<string> _namesPd;
        private string _namePd;
        private int _amountPd;
        private long _importPricePD;
        private long _pricePD;
        private string _unitPd;
        private string _notePd;
        private string  _importDatePd;
        private string _expiryPD;
        private List<string> _supplies;
        private string _supply;
        private List<string> _untisPd;
        private string _imageFile;

        public string namePd { get=> _namePd; set { _namePd = value; OnPropertyChanged(nameof(namePd)); } }
        public List<string> namesPd { get => _namesPd; set { _namesPd = value; OnPropertyChanged(nameof(namesPd)); } }
        public long importPricePD { get => _importPricePD; set { _importPricePD = value; OnPropertyChanged(nameof(importPricePD)); } }
        public string imageFile { get => _imageFile; set { _imageFile = value; OnPropertyChanged(nameof(imageFile));} }
        public string idPd { get => _idPd; set { _idPd = value; OnPropertyChanged(nameof(idPd)); } }
        public int amountPd { get => _amountPd; set { _amountPd = value; OnPropertyChanged(nameof(amountPd)); } }
        public string importDatePd { get => _importDatePd; set { _importDatePd = value; OnPropertyChanged(nameof(importDatePd)); } }
        public long pricePD { get => _pricePD; set { _pricePD = value; OnPropertyChanged(nameof(pricePD)); } }

        public string unitPd { get => _unitPd; set { _unitPd = value; OnPropertyChanged(nameof(unitPd)); } }
        public string notePd { get => _notePd; set { _notePd = value; OnPropertyChanged(nameof(_notePd)); } }
        public string expiryPD { get => _expiryPD; set { _expiryPD = value; OnPropertyChanged(nameof(expiryPD)); } }
        public List<string> supplies { get => _supplies; set { _supplies = value; OnPropertyChanged(nameof(supplies)); } }

        public string supply { get => _supply; set { _supply = value; OnPropertyChanged(nameof(supply)); } }





        private bool CanExecuteAddProducts(object obj)
        {
            
            return true;
        }

        public void ExecuteAddProducts(object obj)
        {

            if (namePd == null)
                MessageBox.Show("Vui lòng điền tên sản phẩm");
            if(importPricePD == 0)
                MessageBox.Show("Vui lòng điền gía nhập sản phẩm");
            if (idPd == null)
                MessageBox.Show("Vui lòng điền mã sản phẩm");
            if (importDatePd == null)
                MessageBox.Show("Vui lòng điền ngày nhâp hàng");
            if (expiryPD == null)
                MessageBox.Show("Vui lòng điền ngày hết hạn");
            if (imageFile == null)
                MessageBox.Show("Vui lòng điền đường dẫn hình ảnh");
            if (supply == null)
                MessageBox.Show("Vui lòng chọn nguồn cung cấp");
            if (unitPd == null)
                MessageBox.Show("Vui lòng điền đơn vị tính");
            else { 
                ProductModel pd = new ProductModel();
                pd.Name = namePd;
                pd.Price = pricePD;
                pd.Expiry = expiryPD.ToString();
                pd.Id = idPd;
                pd.Supply = supply;
                pd.Amount = amountPd;
                pd.ImagePath = imageFile;
                pd.Description = notePd;
                pd.Import_Price = importPricePD;
                pd.Import_Date = importDatePd.ToString();
                ProductRepository repository = new ProductRepository();
                repository.Add(pd);
                MessageBox.Show("Đã thêm thành công");
                //StorageViewModel storageViewModel = new StorageViewModel();
                
                

            }
        }



        public AddProductsViewModel()
        {
            
            importDatePd = DateTime.Now.ToString("yyyy-MM-dd");
            expiryPD = DateTime.Now.ToString("yyyy-MM-dd");

            Add = new ViewModelCommand(ExecuteAddProducts, CanExecuteAddProducts);
            imageFile = @"D:\C# Assignment\DoAn\QLBH\QLBH\Images\productImageExample.png";
        }
        


    }
}
