using Calabonga.EntityFrameworkCore.Entities.Base;
using System;

namespace Calabonga.RichDomainModelDemo.Entities
{
    public class OrderItem : Identity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
