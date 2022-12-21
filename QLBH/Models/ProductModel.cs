using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public double Price { get; set; }
        public System.DateTime Date { get; set; }
        public int InitialAmount { get; set; }
        public int CurrentAmount { get; set; }
        public long Capital { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public string ImagePath { get; set; }

        public ProductModel(string _name, string _id, long _price)
        {
            Name = _name;
            Id = _id;
            Price = _price;
            Date = new System.DateTime();
            InitialAmount = 0;
            CurrentAmount = 0;
            Capital = 0;
            Description = "";
            ProductType = "";
            ImagePath = "";
        }



        public ProductModel()
        {
            
        }
    }
}
