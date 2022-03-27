using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderApiMicroservice.Data.Repository.v1;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Query {
    public class GetOrderByCustomerGuidQueryHandler : IRequestHandler<GetOrderByCustomerGuidQuery, List<Order>> {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByCustomerGuidQueryHandler(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetOrderByCustomerGuidQuery request, CancellationToken cancellationToken) {
            var res = await _orderRepository.GetOrderByCustomerGuidAsync(request.CustomerId, cancellationToken);
            if (request.NewFullname != null) {
                res.ForEach(order => order.CustomerFullName = request.NewFullname);
                await _orderRepository.UpdateRangeAsync(res);
            }
            return res;
        }
    }
}