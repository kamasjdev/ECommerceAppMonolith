﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Sales.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
