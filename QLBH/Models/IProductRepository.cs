using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models
{
    public interface IProductRepository
    {
        ProductModel GetProductById(int id);
        ProductModel GetProductByName(string name);

        void Add(ProductModel product);
        void Edit(ProductModel product);
        void Remove(int id);

        List<ProductModel> GetByAll();



    }
}
