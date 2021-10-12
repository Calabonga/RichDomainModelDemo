using Calabonga.RichDomainModelDemo.Data.Base;
using Calabonga.RichDomainModelDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calabonga.RichDomainModelDemo.Data
{
    /// <summary>
    /// Database context for current application
    /// </summary>
    public class ApplicationDbContext : DbContextBase, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public DbSet<Document> Documents { get; set; }
        
        public DbSet<Participant> Participants { get; set; }

        #region System

        public DbSet<ApplicationUserProfile> Profiles { get; set; }

        /// <inheritdoc />
        public DbSet<MicroservicePermission> Permissions { get; set; }

        #endregion
    }
}