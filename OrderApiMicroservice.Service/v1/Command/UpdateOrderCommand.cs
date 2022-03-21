using System.Collections.Generic;
using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Command
{
    public class UpdateOrderCommand : IRequest
    {
        public List<Order> Orders { get; set; }
    }
}