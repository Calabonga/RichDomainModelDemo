using Calabonga.RichDomainModelDemo.Data.ModelConfigurations.Base;
using Calabonga.RichDomainModelDemo.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calabonga.RichDomainModelDemo.Data.ModelConfigurations
{
    public class OrderItemModelConfiguration : IdentityModelConfigurationBase<OrderItem>
    {
        /// <summary>
        /// Add custom properties for your entity
        /// </summary>
        /// <param name="builder"></param>
        protected override void AddBuilder(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.OrderId).IsRequired();
        }

        /// <summary>
        /// Table name
        /// </summary>
        /// <returns></returns>
        protected override string TableName() => "OrderItems";
    }
}
