using System;
using System.Collections.Generic;
using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Query
{
    public class GetOrderByCustomerGuidQuery : IRequest<List<Order>>
    {
        public string CustomerId { get; set; }
        public string NewFullname { get; set; }
    }
}