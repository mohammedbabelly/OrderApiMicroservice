using System;
using System.Collections.Generic;
using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderApiMicroservice.Data.Database;
using OrderApiMicroservice.Data.Repository.v1;
using OrderApiMicroservice.Domain.Entities;
using OrderApiMicroservice.Service.v1.Command;
using OrderApiMicroservice.Service.v1.Models;
using OrderApiMicroservice.Service.v1.Query;

namespace OrderApiMicroservice.Service.v1.Services {
    public class CustomerNameUpdateService : ICustomerNameUpdateService {
        private IMediator _mediator;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CustomerNameUpdateService(IMediator mediator, IServiceScopeFactory serviceScopeFactory) {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
        }


        public async void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel) {
            try {
                var ordersOfCustomer = new List<Order>();
                using (var scope = _serviceScopeFactory.CreateScope()) {

                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    ordersOfCustomer = await mediator.Send(new GetOrderByCustomerGuidQuery {
                        CustomerId = updateCustomerFullNameModel.Id,
                        NewFullname = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}"
                    });
                }

                //if (ordersOfCustomer.Count != 0) {
                //    foreach (var order in ordersOfCustomer) {
                //        order.CustomerFullName = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}";
                //        _OrderContext.Order.Update(order);
                //    }
                //}


            } catch (Exception ex) {
                // log an error message here

                Debug.WriteLine(ex.Message);
            }
        }
    }
}