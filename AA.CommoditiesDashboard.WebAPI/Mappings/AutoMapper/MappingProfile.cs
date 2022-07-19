using AutoMapper;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.Services;
using AA.CommoditiesDashboard.Services.Models;

namespace AA.CommoditiesDashboard.WebAPI.Mappings.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Contract, ContractDto>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<NewTradeAction, NewTradeActionDto>().ReverseMap();
            CreateMap<Commodity, CommodityDto>().ReverseMap();
            CreateMap<ModelResult, ModelResultDto>().ReverseMap();
        }
    }
}
