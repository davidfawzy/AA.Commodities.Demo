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
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<ModelDto>> GetAllAsync()
        {
            var result = await _modelRepository.GetAsync(null, null, "ModelResult,ModelResult.Position,ModelResult.Contract,ModelResult.NewTradeAction,ModelResult.Commodity");
            return _mapper.Map<List<ModelDto>>(result);
        }

        public async Task<List<MetricsDto>> GetAllYearlyPnlPriceMetricsAsync()
        {
            var model = new List<MetricsDto>();
            var modelDbResult = await _modelRepository.GetAsync(null, null, "ModelResult,ModelResult.Position,ModelResult.Contract,ModelResult.NewTradeAction,ModelResult.Commodity");

            foreach (var item in modelDbResult)
            {
                var result = ArrangePriceData(item);
                model.Add(result);
            }

            return model;
        }

        private MetricsDto ArrangePriceData(Model modelDbResult)
        {
            if (modelDbResult == null) throw new ArgumentNullException("modelDbResult is null");

            var model = new MetricsDto();
            model.Id = modelDbResult.Id;
            model.Name = modelDbResult.Name;

            var grpModelResult = modelDbResult.ModelResult.GroupBy(x => x.Date.Year);

            foreach (var grpItem in grpModelResult)
            {
                var priceData = new PriceYTDDto();
                priceData.Year = grpItem.Key;
                priceData.CummulativePrice = grpItem.Sum(cs => cs.Price);
                priceData.CummulativePnl = grpItem.Sum(cs => cs.PnlDaily);
                model.Prices.Add(priceData);
            }
            return model;
        }
    }
}
