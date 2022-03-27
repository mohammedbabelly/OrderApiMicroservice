using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Data.Repository.v1
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken);

        Task<Order> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken);

        Task<List<Order>> GetOrderByCustomerGuidAsync(string customerId, CancellationToken cancellationToken);
    }
}