using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;

namespace AA.CommoditiesDashboard.DataAccess.Repositories
{
    public class NewTradeActionRepository : Repository<NewTradeAction>, INewTradeActionRepository
    {
        private readonly IAnalyticsDbContext _context;
        public NewTradeActionRepository(IAnalyticsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
