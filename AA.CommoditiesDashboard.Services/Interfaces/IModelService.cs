using AA.CommoditiesDashboard.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Services.Interfaces
{
    public interface IModelService
    {
        Task<List<ModelDto>> GetAllAsync();
        Task<List<MetricsDto>> GetAllYearlyPnlPriceMetricsAsync();
    }
}
