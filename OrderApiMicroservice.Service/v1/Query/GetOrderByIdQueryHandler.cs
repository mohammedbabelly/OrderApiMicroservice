﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrderApiMicroservice.Domain.Entities;
using OrderApiMicroservice.Data.Repository.v1;

namespace OrderApiMicroservice.Service.v1.Query
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderByIdAsync(request.Id, cancellationToken);
        }
    }
}