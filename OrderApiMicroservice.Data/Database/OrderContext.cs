using Microsoft.EntityFrameworkCore;
using OrderApiMicroservice.Domain.Entities;

namespace OrderApiMicroservice.Data.Database {
    public class OrderContext : DbContext {
        public OrderContext() {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options) {
        }

        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
    }
}