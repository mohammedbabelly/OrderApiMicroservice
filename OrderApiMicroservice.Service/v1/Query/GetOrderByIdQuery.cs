using System;
using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Query
{
   public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
