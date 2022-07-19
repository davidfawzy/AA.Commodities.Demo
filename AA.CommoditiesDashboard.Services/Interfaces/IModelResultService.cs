using AA.CommoditiesDashboard.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Services.Interfaces
{
    public interface IModelResultService
    {
        Task<List<ModelResultDto>> GetAllAsync();
    }
}
