using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.ViewModels
{
    public class AddProductPortfolioViewModel : ViewModelBase
    {
        private List<string> _unit;



        public List<string> Unit { get { return _unit; } set { _unit = value; OnPropertyChanged(nameof(Unit)); } }


        AddProductPortfolioViewModel() { 
            
            Unit = new List<string>() { "Cái", "Chai", "Lon", "Lít", "Kg"};

        
        
        
        }
        
    }
}
