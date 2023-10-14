using Calabonga.Microservices.Core.Extensions;
using System;
using System.Security.Principal;

namespace Calabonga.RichDomainModelDemo.Web.Extensions
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// Returns true/false user is owner
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool IsOwner(this IIdentity source, Guid userId) => source.GetSubjectId().ToGuid() == userId;
    }
}
