using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using OrderApiMicroservice.Data.Database;
using OrderApiMicroservice.Data.Repository.v1;
using OrderApiMicroservice.Messaging.Receive.Options.v1;
using OrderApiMicroservice.Messaging.Receive.Receiver.v1;
using OrderApiMicroservice.Service.v1.Services;
using OrderApiMicroservice.Service.v1.Command;
using OrderApiMicroservice.Domain.Entities;
using OrderApiMicroservice.Service.v1.Query;
using OrderApiMicroservice.Validators.v1;
using OrderApiMicroservice.Models.v1;

namespace OrderApiMicroservice {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderApiMicroservice", Version = "v1" });
            });

            services.AddDbContext<OrderContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMvc().AddFluentValidation();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IValidator<OrderModel>, OrderModelValidator>();

            services.AddTransient<IRequestHandler<GetPaidOrderQuery, List<Order>>, GetPaidOrderQueryHandler>();
            services.AddTransient<IRequestHandler<GetOrderByIdQuery, Order>, GetOrderByIdQueryHandler>();
            services.AddTransient<IRequestHandler<GetOrderByCustomerGuidQuery, List<Order>>, GetOrderByCustomerGuidQueryHandler>();
            services.AddTransient<IRequestHandler<CreateOrderCommand, Order>, CreateOrderCommandHandler>();
            services.AddTransient<IRequestHandler<PayOrderCommand, Order>, PayOrderCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
            services.AddTransient<ICustomerNameUpdateService, CustomerNameUpdateService>();


            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfiguration>();
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);

            if (serviceClientSettings.Enabled) {
                services.AddHostedService<CustomerFullNameUpdateReceiver>();
            }


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderApiMicroservice v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
