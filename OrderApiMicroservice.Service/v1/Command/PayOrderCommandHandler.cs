using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderApiMicroservice.Data.Repository.v1;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Command
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public PayOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.UpdateAsync(request.Order);
        }
    }
}