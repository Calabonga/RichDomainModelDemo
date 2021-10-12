using Calabonga.RichDomainModelDemo.Data;
using Calabonga.RichDomainModelDemo.Web.Infrastructure.Auth;
using Calabonga.RichDomainModelDemo.Web.Infrastructure.Services;
using IdentityServer4.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.RichDomainModelDemo.Web.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Registrations for both points: API and Scheduler
    /// </summary>
    public partial class DependencyContainer
    {
        /// <summary>
        /// Register 
        /// </summary>
        /// <param name="services"></param>
        public static void Common(IServiceCollection services)
        {
            services.AddTransient<ApplicationUserStore>();
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ApplicationClaimsPrincipalFactory>();

            // services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IProfileService, IdentityProfileService>();
            services.AddTransient<ICorsPolicyService, IdentityServerCorsPolicy>();
            
            // manager
            services.AddTransient<OrderManager>();
        }
    }
}
