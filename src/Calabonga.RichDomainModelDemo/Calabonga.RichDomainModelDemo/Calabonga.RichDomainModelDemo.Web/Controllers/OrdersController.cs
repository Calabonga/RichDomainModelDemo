using Calabonga.RichDomainModelDemo.Entities;
using Calabonga.RichDomainModelDemo.Web.Infrastructure.Services;
using Calabonga.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calabonga.RichDomainModelDemo.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly OrderManager _orderManager;

        public OrdersController(IUnitOfWork unitOfWork,
            OrderManager orderManager)
        {
            _unitOfWork = unitOfWork;
            _orderManager = orderManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateOrder(string name)
        {
            var repository = _unitOfWork.GetRepository<Order>();

            var exists = await repository.GetFirstOrDefaultAsync(predicate: x => x.Title.ToLower().Equals(name.ToLower()));
            if (exists is not null)
            {
                return BadRequest("Already exists");
            }

            var order = _orderManager.Create("Order #3213");

            var o = new Order() { };

            var status = order.Status;

            var orderItem1 = new OrderItem { Name = "one" };
            var orderItem2 = new OrderItem { Name = "two" };

            _orderManager.AddOrderItem(order, orderItem1);

            _orderManager.SetStatus(order, OrderStatus.Complete);

            _orderManager.AddOrderItem(order, orderItem2);

            _orderManager.SetStatus(order, OrderStatus.Complete);
            
            await repository.InsertAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrders()
        {
            var repository = _unitOfWork.GetRepository<Order>();
            return Ok(repository.GetAll(true).ToList());
        }
    }
}
