using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.CommoditiesDashboard.DataAccess.Repositories
{
    public class CommodityRepository : Repository<Commodity>, ICommodityRepository
    {
        private readonly IAnalyticsDbContext _context;
        public CommodityRepository(IAnalyticsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
