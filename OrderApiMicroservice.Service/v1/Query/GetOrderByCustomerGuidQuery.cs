using System;
using System.Collections.Generic;
using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Query
{
    public class GetOrderByCustomerGuidQuery : IRequest<List<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}