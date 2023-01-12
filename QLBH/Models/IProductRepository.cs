using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QLBH.Models
{
    public interface IProductRepository
    {
        ProductModel GetProductById(int id);
        ProductModel GetProductByName(string name);
        double GetPriceByName(string name);

        string GetIdByName(string name);

        void Add(ProductModel product);
        void Modify(ProductModel product);
        void Remove(string id);
        void RemovePP(string id);
        List<string> getNameAll();

        //List<ProductModel> Find(string id, string name);
        ObservableCollection<ProductModel> GetByAll(string id);
        ObservableCollection<ProductPortfolio> GetByAllProductPortfolio();





    }
}
