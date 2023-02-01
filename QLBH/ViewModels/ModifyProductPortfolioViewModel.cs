using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;

namespace QLBH.ViewModels
{
    public class ModifyProductPortfolioViewModel : ViewModelBase
    {
        private List<string> _unit;
        private string _selectPath;
        private string _path;
        private string _name;
        private string _selectedU;


        public List<string> Unit { get { return _unit; } set { _unit = value; OnPropertyChanged(nameof(Unit)); } }
        public string SelectPath { get { return _selectPath; } set { _selectPath = value; OnPropertyChanged(nameof(SelectPath)); } }
        public string Path { get { return _path; } set { _path = value; OnPropertyChanged(nameof(Path)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string SelectedU { get { return _selectedU; } set { _selectedU = value; OnPropertyChanged(nameof(SelectedU)); } }
        public ICommand selectFileImg { get; set; }

        public void ExecuteSelect(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            SelectPath = openFileDialog.FileName;
            Path = SelectPath;

        }


        public ModifyProductPortfolioViewModel() {
            Unit = new List<string>() { "Cái", "Chai", "Lon", "Lít", "Kg" };
            selectFileImg = new ViewModelCommand(ExecuteSelect);
            Path = @"C:\\Users\\Admin\\source\\repos\\QLBH\\QLBH\\Images\\img.PNG";
        }
        public ModifyProductPortfolioViewModel(ProductPortfolio pdp) {
            Unit = new List<string>() { "Cái", "Chai", "Lon", "Lít", "Kg" };
            Path = pdp.ImageLink;
            SelectedU = pdp.Unit;
            Name = pdp.NamePP;
            selectFileImg = new ViewModelCommand(ExecuteSelect);



        }

    }
}
