using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Command
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
