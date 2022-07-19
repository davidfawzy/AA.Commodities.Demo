using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;

namespace AA.CommoditiesDashboard.DataAccess.Repositories
{
    public class ModelResultRepository : Repository<ModelResult>, IModelResultRepository
    {
        private readonly IAnalyticsDbContext _context;
        public ModelResultRepository(IAnalyticsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
