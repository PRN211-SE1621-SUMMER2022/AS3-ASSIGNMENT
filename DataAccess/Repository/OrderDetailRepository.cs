using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.DeleteOrderDetail(orderDetail);

        public IEnumerable<OrderDetail> GetAllOrderDetail(int OrderId) => OrderDetailDAO.Instance.GetAllOrderDetail(OrderId);

        public OrderDetail GetOrderDetailByID(int orderID, int productID) => OrderDetailDAO.Instance.GetOrderDetailByID(orderID, productID);

        public IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailByOrderID(orderID);

        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.InsertOrderDetail(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
    }
}
