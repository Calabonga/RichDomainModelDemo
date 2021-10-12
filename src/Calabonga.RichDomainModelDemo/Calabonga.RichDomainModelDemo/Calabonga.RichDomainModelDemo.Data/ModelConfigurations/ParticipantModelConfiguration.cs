using Calabonga.RichDomainModelDemo.Data.ModelConfigurations.Base;
using Calabonga.RichDomainModelDemo.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calabonga.RichDomainModelDemo.Data.ModelConfigurations
{
    public class ParticipantModelConfiguration : IdentityModelConfigurationBase<Participant>
    {
        /// <summary>
        /// Add custom properties for your entity
        /// </summary>
        /// <param name="builder"></param>
        protected override void AddBuilder(EntityTypeBuilder<Participant> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.DocumentId).IsRequired();
        }

        /// <summary>
        /// Table name
        /// </summary>
        /// <returns></returns>
        protected override string TableName() => "Participants";
    }
}
