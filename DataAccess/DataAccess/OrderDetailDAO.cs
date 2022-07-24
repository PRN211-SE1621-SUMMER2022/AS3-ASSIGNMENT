using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrderDetailDAO : BaseDAO<OrderDetail>, IOrderDetailRepository
    {
        private static readonly object instanceLock = new object();
        private SaleManagementDBContext salesManagementContext = new SaleManagementDBContext();
        public static OrderDetailDAO instance = null;


        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                }
                return instance;
            }
        }
        public void DeleteOrderDetail(OrderDetail orderDetail) => base.DeleteEntity(orderDetail);

        public IEnumerable<OrderDetail> GetAllOrderDetail(int orderID) => salesManagementContext.OrderDetails.Where(o => o.OrderId == orderID).ToList();

        public OrderDetail GetOrderDetailByID(int orderID, int productID) => salesManagementContext.OrderDetails.Where(o => o.OrderId == orderID && o.ProductId == productID).SingleOrDefault();

        public void InsertOrderDetail(OrderDetail orderDetail) => base.SaveEntity(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => base.UpdateEntity(orderDetail);

        public IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID) => salesManagementContext.OrderDetails.Where(o => o.OrderId == orderID).Include(o => o.Product).ToList();
    }
}
