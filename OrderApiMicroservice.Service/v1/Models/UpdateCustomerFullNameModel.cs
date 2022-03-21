using System;

namespace OrderApiMicroservice.Service.v1.Models
{
    public class UpdateCustomerFullNameModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}