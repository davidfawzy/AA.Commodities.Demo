using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;

namespace AA.CommoditiesDashboard.DataAccess.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        private readonly IAnalyticsDbContext _context;
        public ContractRepository(IAnalyticsDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
