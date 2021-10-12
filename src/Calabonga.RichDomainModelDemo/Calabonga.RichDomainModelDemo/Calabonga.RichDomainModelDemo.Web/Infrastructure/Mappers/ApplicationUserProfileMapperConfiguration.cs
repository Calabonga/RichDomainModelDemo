using Calabonga.RichDomainModelDemo.Data;
using Calabonga.RichDomainModelDemo.Web.Infrastructure.Mappers.Base;
using Calabonga.RichDomainModelDemo.Web.ViewModels.AccountViewModels;

namespace Calabonga.RichDomainModelDemo.Web.Infrastructure.Mappers
{
    /// <summary>
    /// Mapper Configuration for entity Person
    /// </summary>
    public class ApplicationUserProfileMapperConfiguration : MapperConfigurationBase
    {
        /// <inheritdoc />
        public ApplicationUserProfileMapperConfiguration() => CreateMap<RegisterViewModel, ApplicationUserProfile>()
            .ForAllOtherMembers(x => x.Ignore());
    }
}