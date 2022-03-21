using OrderApiMicroservice.Service.v1.Models;

namespace OrderApiMicroservice.Service.v1.Services
{
    public interface ICustomerNameUpdateService
    {
        void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel);
    }
}