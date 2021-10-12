using Calabonga.RichDomainModelDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Calabonga.RichDomainModelDemo.Web.Infrastructure.Services
{
    public class OrderManager
    {
        public Order Create(string name)
        {
            var order = new Order
            {
                Title = name,
                OrderItems = new List<OrderItem>()
            };
            order.Status = OrderStatus.Draft;
            order.Description = "без названия";
            return order;
        }

        public void AddOrderItem(Order order, OrderItem item)
        {
            if (!order.OrderItems.Select(x => x.Name).Contains(item.Name))
            {
                order.OrderItems.Add(item);
                if (order.Status == OrderStatus.Draft && order.OrderItems.Count > 1)
                {
                    order.Status = OrderStatus.InWork;
                }
            }
        }

        public bool SetStatus(Order order, OrderStatus status)
        {
            if (CanSetStatus(order, status))
            {
                order.Status = status;
                return true;
            }
            return false;
        }

        private bool CanSetStatus(Order order, OrderStatus status) => order.Status switch
        {
            OrderStatus.None => false,
            OrderStatus.Draft => false,
            OrderStatus.InWork => true && order.OrderItems!.Count > 1,
            OrderStatus.Complete => false,
            _ => false
        };
    }
}
