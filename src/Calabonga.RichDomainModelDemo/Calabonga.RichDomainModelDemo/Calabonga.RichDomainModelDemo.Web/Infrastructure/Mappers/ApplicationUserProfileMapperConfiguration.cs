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
        public ApplicationUserProfileMapperConfiguration()
            => CreateMap<RegisterViewModel, ApplicationUserProfile>()
                .ForMember(x => x.ApplicationUser, o => o.Ignore())
                .ForMember(x => x.Permissions, o => o.Ignore())
                .ForMember(x => x.CreatedAt, o => o.Ignore())
                .ForMember(x => x.CreatedBy, o => o.Ignore())
                .ForMember(x => x.UpdatedBy, o => o.Ignore())
                .ForMember(x => x.UpdatedAt, o => o.Ignore())
                .ForMember(x => x.Id, o => o.Ignore());
    }
}