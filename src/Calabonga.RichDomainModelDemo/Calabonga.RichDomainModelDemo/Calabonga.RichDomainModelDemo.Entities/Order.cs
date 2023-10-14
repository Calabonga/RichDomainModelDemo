using Calabonga.RichDomainModelDemo.Entities.Base;
using System.Collections.Generic;

namespace Calabonga.RichDomainModelDemo.Entities
{
    public class Order: Identity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
