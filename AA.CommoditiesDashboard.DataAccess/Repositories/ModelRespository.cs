using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;

namespace AA.CommoditiesDashboard.DataAccess.Repositories
{
    public class ModelRespository : Repository<Model>, IModelRepository
    {
        private readonly IAnalyticsDbContext _context;
        public ModelRespository(IAnalyticsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
