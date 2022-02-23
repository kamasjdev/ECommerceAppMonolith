﻿using ECommerce.Modules.Sales.Domain.ItemSales.Repositories;
using ECommerce.Modules.Sales.Infrastructure.EF;
using ECommerce.Modules.Sales.Infrastructure.EF.Repositories;
using ECommerce.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Modules.Sales.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IItemRepository, InMemoryItemRepository>();
            services.AddSingleton<IItemSaleRepository, InMemoryItemSaleRepository>();
            services.AddPostgres<SalesDbContext>();
            return services;
        }
    }
}