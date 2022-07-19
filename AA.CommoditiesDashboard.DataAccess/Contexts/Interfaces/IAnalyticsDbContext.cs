using AA.CommoditiesDashboard.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces
{
    public interface IAnalyticsDbContext
    {
        DbSet<Model> Model { get; set; }
        DbSet<Contract> Contract { get; set; }
        DbSet<NewTradeAction> NewTradeAction { get; set; }
        DbSet<Position> Position { get; set; }
        DbSet<ModelResult> ModelResult { get; set; }
        DbSet<Commodity> Commodity { get; set; }
        void Dispose();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        DatabaseFacade Database { get; }
    }
}
