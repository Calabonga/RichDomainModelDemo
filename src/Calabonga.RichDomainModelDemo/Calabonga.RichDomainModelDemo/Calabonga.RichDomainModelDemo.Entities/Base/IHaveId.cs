using System;

namespace Calabonga.RichDomainModelDemo.Entities.Base
{
    /// <summary>
    /// Identifier interface
    /// </summary>
    public interface IHaveId
    {
        /// <summary>
        /// Identifier
        /// </summary>
        Guid Id { get; set; }
    }
}
