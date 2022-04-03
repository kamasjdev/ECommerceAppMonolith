﻿using ECommerce.Modules.Currencies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Currencies.Core.Repositories
{
    internal interface ICurrencyRateRepository
    {
        Task AddAsync(CurrencyRate currencyRate);
        Task<CurrencyRate> GetAsync(Guid id);
        Task<IReadOnlyList<CurrencyRate>> GetAllAsync();
        Task<CurrencyRate> GetCurrencyRateForDateAsync(Guid currencyId, DateOnly date);
        Task<IReadOnlyList<CurrencyRate>> GetCurrencyRatesForDate(IEnumerable<string> currencyCodes, DateOnly date);
        Task UpdateAsync(CurrencyRate rate);
    }
}
