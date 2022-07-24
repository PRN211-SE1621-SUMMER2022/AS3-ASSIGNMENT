using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order order) => OrderDAO.Instance.DeleteOrder(order);

        public IEnumerable<Order> GetAllOfMember(int memberId) => OrderDAO.Instance.GetByMemberId(memberId);

        public IEnumerable<Order> GetAllOrder() => OrderDAO.Instance.GetAllOrder();

        public Order GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);

        public void InsertOrder(Order order) => OrderDAO.Instance.InsertOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);

        public IEnumerable<Order> SortDescByDate() => OrderDAO.Instance.SortDescByDate();

        public IEnumerable<Order> FilterByDate(DateTime start, DateTime end) => OrderDAO.Instance.FilterByDate(start, end);

        public IEnumerable<Order> GetByMemberId(int memberId) => OrderDAO.Instance.GetByMemberId(memberId);

        public IEnumerable<Order> GetList() => OrderDAO.Instance.GetList();
    }
}
