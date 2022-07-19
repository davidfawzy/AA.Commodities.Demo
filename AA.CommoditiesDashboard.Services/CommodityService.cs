using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services.Interfaces;
using AA.CommoditiesDashboard.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Services
{
    public class CommodityService : ICommodityService
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;
        public CommodityService(ICommodityRepository commodityRepository, IMapper mapper)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<List<CommodityDto>> GetAllAsync()
        {
            var result = await _commodityRepository.GetAsync(null, null, "ModelResult,ModelResult.Position,ModelResult.Contract,ModelResult.NewTradeAction");
            return _mapper.Map<List<CommodityDto>>(result);
        }

        public async Task<List<HistoricalCommodityDto>> GetAllPnlYTDMetricAsync()
        {
            var model = new List<HistoricalCommodityDto>();
            var modelDbResult = await _commodityRepository.GetAsync(null, null, "ModelResult,ModelResult.Position,ModelResult.Contract,ModelResult.NewTradeAction");

            foreach (var item in modelDbResult)
            {
                var result = ArrangeHistoricalData(item);
                model.Add(result);
            }
            return model;
        }

        public async Task<HistoricalCommodityDto> GetPnlYTDMetricByIdAsync(int id)
        {
            var modelDbResult = await _commodityRepository.GetAsync(com => com.Id == id, null, "ModelResult,ModelResult.Position,ModelResult.Contract,ModelResult.NewTradeAction");
            var result = ArrangeHistoricalData(modelDbResult.FirstOrDefault());
            return result;
        }

        private HistoricalCommodityDto ArrangeHistoricalData(Commodity modelDbResult)
        {
            if (modelDbResult == null) throw new ArgumentNullException("modelDbResult is null");

            var model = new HistoricalCommodityDto();
            model.Id = modelDbResult.Id;
            model.Name = modelDbResult.Name;

            var grpModelResult = modelDbResult.ModelResult.GroupBy(x => x.Date.Year);

            foreach (var grpItem in grpModelResult)
            {
                var historicalData = new HistoricalPnlByYearsDto();
                historicalData.Year = grpItem.Key;
                historicalData.CummulativePnl = grpItem.Sum(cs => cs.PnlDaily);

                foreach (var rItem in grpItem)
                {
                    var mappedDtoItems = _mapper.Map<ModelResultDto>(rItem);
                    historicalData.ModelResults.Add(mappedDtoItems);
                }
                model.Metrics.Add(historicalData);
            }
            return model;
        }

    }
}
