using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
        Order GetOrderByID(int orderID);
        void InsertOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetAllOfMember(int memberId);
        public IEnumerable<Order> GetByMemberId(int memberId);
        public IEnumerable<Order> FilterByDate(DateTime start, DateTime end);
        public IEnumerable<Order> SortDescByDate();

    }
}
