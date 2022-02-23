﻿using ECommerce.Modules.Sales.Domain.Payments.Entities;
using ECommerce.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Sales.Infrastructure.EF.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .HasConversion(id => id.Value, id => new AggregateId(id));

            builder.Property(o => o.PaymentNumber).IsRequired().HasMaxLength(50);

            builder
                .Property(i => i.Version)
                .IsConcurrencyToken();
        }
    }
}
