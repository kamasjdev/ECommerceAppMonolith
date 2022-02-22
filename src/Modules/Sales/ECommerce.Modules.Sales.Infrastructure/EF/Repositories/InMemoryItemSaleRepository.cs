﻿using ECommerce.Modules.Sales.Domain.ItemSales.Entities;
using ECommerce.Modules.Sales.Domain.ItemSales.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Sales.Infrastructure.EF.Repositories
{
    internal sealed class InMemoryItemSaleRepository : IItemSaleRepository
    {
        public Task AddAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemSale> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemSale itemSale)
        {
            throw new NotImplementedException();
        }
    }
}
