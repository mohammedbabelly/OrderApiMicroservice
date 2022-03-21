using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderApiMicroservice.Data.Repository.v1;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Query
{
    public class GetPaidOrderQueryHandler : IRequestHandler<GetPaidOrderQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetPaidOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetPaidOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetPaidOrdersAsync(cancellationToken);
        }
    }
}