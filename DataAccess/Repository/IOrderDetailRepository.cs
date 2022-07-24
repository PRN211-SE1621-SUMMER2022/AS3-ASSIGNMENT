using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAllOrderDetail(int OrderId);
        OrderDetail GetOrderDetailByID(int orderID, int productID);
        IEnumerable<OrderDetail> GetOrderDetailByOrderID(int orderID);
        void InsertOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);

    }
}
