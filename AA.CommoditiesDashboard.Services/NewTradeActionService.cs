using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Services
{
    public class NewTradeActionService : INewTradeActionService
    {
        private readonly INewTradeActionRepository _newTradeActionRepository;
        private readonly IMapper _mapper;
        public NewTradeActionService(INewTradeActionRepository newTradeActionRepository, IMapper mapper)
        {
            _newTradeActionRepository = newTradeActionRepository;
            _mapper = mapper;
        }

        public async Task<List<NewTradeActionDto>> GetAllAsync()
        {
            var result = await _newTradeActionRepository.GetAsync();
            return _mapper.Map<List<NewTradeActionDto>>(result);
        }
    }
}
