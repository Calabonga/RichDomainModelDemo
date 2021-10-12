using Calabonga.RichDomainModelDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Calabonga.RichDomainModelDemo.Data
{
    /// <summary>
    /// Abstraction for Database (EntityFramework)
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }

        DbSet<OrderItem> OrderItems { get; set; }

        DbSet<Document> Documents { get; set; }

        DbSet<Participant> Participants { get; set; }

        #region System

        DbSet<ApplicationUser> Users { get; set; }

        DbSet<ApplicationUserProfile> Profiles { get; set; }

        DbSet<MicroservicePermission> Permissions { get; set; }

        DatabaseFacade Database { get; }

        ChangeTracker ChangeTracker { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        #endregion
    }
}