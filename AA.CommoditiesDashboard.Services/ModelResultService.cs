using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services.Interfaces;
using AA.CommoditiesDashboard.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Services
{
    public class ModelResultService : IModelResultService
    {
        private readonly IModelResultRepository _modelResultRepository;
        private readonly IMapper _mapper;
        public ModelResultService(IModelResultRepository modelResultRepository, IMapper mapper)
        {
            _modelResultRepository = modelResultRepository;
            _mapper = mapper;
        }

        public async Task<List<ModelResultDto>> GetAllAsync()
        {
            var result = await _modelResultRepository.GetAsync(null, null, "Contract,Position,NewTradeAction");
            return _mapper.Map<List<ModelResultDto>>(result);
        }
    }
}
