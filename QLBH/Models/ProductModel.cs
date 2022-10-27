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
        public long Price { get; set; }
        public System.DateTime Date { get; set; }
        public int InitialAmount { get; set; }
        public int CurrentAmount { get; set; }
        public long Capital { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public string ImagePath { get; set; }

        //public ProductModel()
        //{
        //    Name = "";
        //    Id = "";
        //    Price = 0;
        //    Date = new System.DateTime();
        //    InitialAmount = 0;  
        //    CurrentAmount = 0;
        //    Capital = 0;
        //    Description = "";
        //    ProductType = "";
        //    ImagePath = "";
        //}

    }
}
