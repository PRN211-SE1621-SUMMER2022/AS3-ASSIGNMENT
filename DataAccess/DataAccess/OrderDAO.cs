using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : BaseDAO<Order>, IOrderRepository
    {
        private static readonly object instanceLock = new object();
        public static OrderDAO instance = null;
        private SaleManagementDBContext salesManagementContext = new SaleManagementDBContext();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                }
                return instance;
            }
        }
        public void DeleteOrder(Order order) => base.DeleteEntity(order);

        public Order GetOrderByID(int orderID) => base.GetEntityById(orderID);

        public IEnumerable<Order> GetAllOrder() => base.GetAllEntity();

        public void InsertOrder(Order order) => base.SaveEntity(order);

        public void UpdateOrder(Order order) => base.UpdateEntity(order);
        public IEnumerable<Order> GetByMemberId(int memberId) => salesManagementContext.Orders.Where(o => o.MemberId == memberId).Include(o => o.OrderDetails);

        public IEnumerable<Order> GetAllOfMember(int memberId)
        => salesManagementContext.Orders.Where(o => o.MemberId == memberId).Include(o => o.OrderDetails);

        public IEnumerable<Order> FilterByDate(DateTime startDate, DateTime endate)
    => salesManagementContext.Orders.Where(o => (o.OrderDate.Date.CompareTo(startDate.Date) >= 0 && o.OrderDate.Date.CompareTo(endate.Date) <= 0)).ToList().OrderByDescending(o => o.OrderDate);

        public IEnumerable<Order> SortDescByDate()
            => salesManagementContext.Orders.ToList().OrderByDescending(o => o.OrderDate);
    }
}
