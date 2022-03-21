using System.Collections.Generic;
using MediatR;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Service.v1.Query
{
    public class GetPaidOrderQuery : IRequest<List<Order>>
    {
    }
}