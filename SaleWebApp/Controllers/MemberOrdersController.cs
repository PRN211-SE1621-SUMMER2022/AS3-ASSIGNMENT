using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace SaleWebApp.Controllers
{
    public class MemberOrdersController : Controller
    {
        IOrderRepository orderRepository;
        IOrderDetailRepository orderDetailRepository;
        IProductRepository productRepository;
        static int id;
        public MemberOrdersController()
        {
            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailRepository();
        }
        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                MemberOrdersController.id = (int)id;
                return View(orderRepository.GetAllOfMember(id.Value));
            }
            else
            {
                return View(orderRepository.GetAllOfMember(MemberOrdersController.id));
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            return View(orderDetailRepository.GetOrderDetailByOrderID(id.Value));
        }
    }
}
