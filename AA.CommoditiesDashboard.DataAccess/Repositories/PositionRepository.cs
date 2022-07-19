using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;

namespace AA.CommoditiesDashboard.DataAccess.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly IAnalyticsDbContext _context;
        public PositionRepository(IAnalyticsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}