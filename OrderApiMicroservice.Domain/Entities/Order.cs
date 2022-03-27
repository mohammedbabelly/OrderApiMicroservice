using System;

namespace OrderApiMicroservice.Domain.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public int OrderState { get; set; }

        public string CustomerGuid { get; set; }

        public string CustomerFullName { get; set; }
    }
}
