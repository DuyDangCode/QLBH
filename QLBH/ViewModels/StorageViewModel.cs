using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using QLBH.Repositories;


namespace QLBH.ViewModels
{
    public class StorageViewModel : ViewModelBase
    {
        public List<ProductModel> produces;
        public List<pd> list = new List<pd>();

        public StorageViewModel ()
        {
            ProductRepository p = new ProductRepository();
            produces = p.GetByAll();

            for (int i = 0; i < produces.Count; i++)
            {
                pd a = new pd(produces[i].Name);
                list.Add(a); 
            
            
            }
        }

        public class pd
        {
            string Name;
            string Price = "100";
            string ImagePath = "Images/pd1.jpg";
            public pd (string nn)
            {
                Name = nn;
                Price = "100";
                ImagePath = "Images/pd1.jpg";
            }

        }


    }
}
