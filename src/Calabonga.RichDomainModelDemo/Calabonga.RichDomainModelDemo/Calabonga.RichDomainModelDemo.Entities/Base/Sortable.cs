﻿namespace Calabonga.RichDomainModelDemo.Entities.Base
{
    /// <summary>
    /// Order
    /// </summary>
    public class Sortable: Auditable
    {
        /// <summary>
        /// Sorting index for entity
        /// </summary>
        public int SortIndex { get; set; }
    }
}
