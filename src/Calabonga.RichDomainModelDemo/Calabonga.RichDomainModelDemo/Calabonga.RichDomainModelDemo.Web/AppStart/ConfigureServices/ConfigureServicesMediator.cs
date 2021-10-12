﻿using Calabonga.AspNetCore.Controllers.Extensions;
using Calabonga.RichDomainModelDemo.Web.Mediator.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.RichDomainModelDemo.Web.AppStart.ConfigureServices
{
    /// <summary>
    /// ASP.NET Core services registration and configurations
    /// </summary>
    public static class ConfigureServicesMediator
    {
        /// <summary>
        /// ConfigureServices Services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddCommandAndQueries(typeof(Startup).Assembly);
        }
    }
}