using Microsoft.Extensions.Logging;

namespace Calabonga.RichDomainModelDemo.Web.Infrastructure.EventLogs
{
    /// <summary>
    /// The number identifiers for events in the microservices
    /// </summary>
    static class EventNumbers
    {
        internal static readonly EventId UserRegistrationId = new(9001, nameof(UserRegistrationId));
        internal static readonly EventId PostItemId = new(9002, nameof(PostItemId));
    }
}
