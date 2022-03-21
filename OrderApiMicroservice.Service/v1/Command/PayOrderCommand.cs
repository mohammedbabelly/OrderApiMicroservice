using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Command
{
   public class PayOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
