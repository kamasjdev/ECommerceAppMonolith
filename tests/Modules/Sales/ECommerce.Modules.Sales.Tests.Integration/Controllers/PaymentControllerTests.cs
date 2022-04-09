﻿using ECommerce.Modules.Items.Tests.Integration.Common;
using ECommerce.Modules.Sales.Application.Payments.Commands;
using ECommerce.Modules.Sales.Domain.Orders.Entities;
using ECommerce.Modules.Sales.Domain.Payments.Entities;
using ECommerce.Modules.Sales.Infrastructure.EF;
using ECommerce.Shared.Tests;
using Flurl.Http;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Net;
using Xunit;

namespace ECommerce.Modules.Sales.Tests.Integration.Controllers
{
    public class PaymentControllerTests : BaseIntegrationTest, IClassFixture<TestApplicationFactory<Program>>,
        IClassFixture<TestSalesDbContext>
    {
        [Fact]
        public async Task given_valid_command_should_create_payment()
        {
            var order = await AddOrder("ORD");
            var command = new CreatePayment(order.Id);
            Authenticate(_userId, _client);

            var response = await _client.Request($"{Path}").PostJsonAsync(command);
            var id = response.GetIdFromHeaders<Guid>(Path);

            var payment = _dbContext.Payments.Where(c => c.Id == id).AsNoTracking().SingleOrDefault();
            response.StatusCode.ShouldBe((int)HttpStatusCode.Created);
            payment.ShouldNotBeNull();
        }

        [Fact]
        public async Task given_valid_id_should_delete_payment()
        {
            var payment = await AddPayment("PAY/123");
            Authenticate(_userId, _client);
            
            var response = await _client.Request($"{Path}/{payment.Id.Value}").DeleteAsync();

            response.StatusCode.ShouldBe((int)HttpStatusCode.OK); 
            var paymentFromDb = _dbContext.Payments.Where(c => c.Id == payment.Id.Value).AsNoTracking().SingleOrDefault();
            paymentFromDb.ShouldBeNull();
        }

        private async Task<Order> AddOrder(string orderNumber)
        {
            var order = new Order(Guid.NewGuid(), orderNumber, 100M, "PLN", 1M, Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow);
            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        private async Task<Payment> AddPayment(string paymentNumber)
        {
            var order = await AddOrder("PAY/12356436");
            var payment = new Payment(Guid.NewGuid(), paymentNumber, order, _userId, DateTime.UtcNow);
            await _dbContext.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        private Guid _userId = Guid.NewGuid();
        private const string Path = "sales-module/payments";
        private readonly IFlurlClient _client;
        private readonly SalesDbContext _dbContext;

        public PaymentControllerTests(TestApplicationFactory<Program> factory, TestSalesDbContext dbContext)
        {
            _client = new FlurlClient(factory.CreateClient());
            _dbContext = dbContext.DbContext;
        }
    }
}
