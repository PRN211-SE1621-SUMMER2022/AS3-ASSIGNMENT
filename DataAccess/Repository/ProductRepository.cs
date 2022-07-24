using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProduct() => ProductDAO.Instance.GetAllProduct();

        public Product GetProductById(int productId) => ProductDAO.Instance.GetProductById(productId);

        public IEnumerable<Product> GetProductByName(string productName) => ProductDAO.Instance.GetProductByName(productName);

        public IEnumerable<Product> GetProductByUnitInStock(int unitstock) => ProductDAO.Instance.GetProductByUnitInStock(unitstock);

        public IEnumerable<Product> GetProductByUnitPrice(decimal unitprice) => ProductDAO.Instance.GetProductByUnitPrice(unitprice);

        public void InsertProduct(Product product) => ProductDAO.Instance.InsertProduct(product);

        public void RemoveProduct(Product product) => ProductDAO.Instance.RemoveProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
