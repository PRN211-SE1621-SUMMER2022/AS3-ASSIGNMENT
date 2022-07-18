using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> GetProductByName(String productName);
        Product GetProductById(int productId);
        IEnumerable<Product> GetProductByUnitPrice(decimal unitprice);
        IEnumerable<Product> GetProductByUnitInStock(int unitprice);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
    }
}
