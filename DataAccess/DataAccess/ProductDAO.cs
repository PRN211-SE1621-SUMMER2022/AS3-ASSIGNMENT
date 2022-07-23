using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : BaseDAO<Product>, IProductRepository
    {
        private static readonly object instanceLock = new object();
        public static ProductDAO instance = null;
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance;
            }
        }
        public IEnumerable<Product> GetAllProduct() => base.GetAllEntity();

        public Product GetProductById(int productId) => base.GetEntityById(productId);

        public IEnumerable<Product>? GetProductByName(string productName)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    productName = productName.Trim();
                    return (IEnumerable<Product>)db.Set<Product>()
                        .Where(p => p.ProductName.Contains(productName)).ToList();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public IEnumerable<Product> GetProductByUnitPrice(decimal unitprice)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    return (IEnumerable<Product>)db.Set<Product>()
                        .Where(p => p.UnitPrice<= unitprice).ToList();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public IEnumerable<Product> GetProductByUnitInStock(int unitstock)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    return (IEnumerable<Product>)db.Set<Product>()
                        .Where(p => p.UnitsInStock <= unitstock).ToList();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }



        public void InsertProduct(Product product) => base.SaveEntity(product);

        public void RemoveProduct(Product product) => base.DeleteEntity(product);

        public void UpdateProduct(Product product) => base.UpdateEntity(product);

        
    }
}
