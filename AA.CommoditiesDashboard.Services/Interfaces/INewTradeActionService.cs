using AA.CommoditiesDashboard.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Services.Interfaces
{
    public interface INewTradeActionService
    {
        Task<List<NewTradeActionDto>> GetAllAsync();
    }
}
