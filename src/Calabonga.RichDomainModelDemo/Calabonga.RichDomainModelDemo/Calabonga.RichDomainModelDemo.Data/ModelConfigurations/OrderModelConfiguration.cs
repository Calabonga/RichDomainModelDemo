using Calabonga.RichDomainModelDemo.Data.ModelConfigurations.Base;
using Calabonga.RichDomainModelDemo.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calabonga.RichDomainModelDemo.Data.ModelConfigurations
{
    public class OrderModelConfiguration : IdentityModelConfigurationBase<Order>
    {
        /// <summary>
        /// Add custom properties for your entity
        /// </summary>
        /// <param name="builder"></param>
        protected override void AddBuilder(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.OrderItems);
        }

        /// <summary>
        /// Table name
        /// </summary>
        /// <returns></returns>
        protected override string TableName() => "Orders";
    }
}
