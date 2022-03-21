using AutoMapper;
using OrderApiMicroservice.Domain.Entities;
using OrderApiMicroservice.Models.v1;

namespace OrderApiMicroservice.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>()
                .ForMember(x => x.OrderState, opt => opt.MapFrom(src => 1));
        }
    }
}